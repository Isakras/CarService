(function ($) {
    var _vehicleService = abp.services.app.vehicle,
        l = abp.localization.getSource('Invoice'),
        _$modal = $('#VehicleCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#VehicleTable');

    var _$vehiclesTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        processing: true,
        listAction: {
            ajaxFunction: _vehicleService.getAll,
            inputFilter: function () {
                return $('#VehiclesSearchForm').serializeFormToObject(true);
            }
        },
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-sync-alt"></i>',
                action: () => _$vehiclesTable.draw(false)
            }
        ],
        responsive: {
            details: {
                type: 'column'
            }
        },
        columnDefs: [
         
            {
                targets: 0,
                data: 'id',
                className: 'control',
                defaultContent: '',
                orderable: false,
            },
            {
                targets: 1,
                data: 'make',
                orderable: false,
            },
            {
                targets: 2,
                data: 'vin',
            },
            {
                targets: 3,
                data: 'model',
            },
            {
                targets: 4,
                data: 'year',
            },
            {
                targets: 5,
                data: 'plateNo',
            },
            {
                targets: 6,
                data: 'mileage',
            },
            {
                targets: 7,
                data: 'color',
            },
            {
                targets: 8,
                data: null,
                orderable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row) => {
                    return [
                        `<button type="button" class="btn btn-sm btn-secondary edit-vehicle" data-vehicle-id="${row.id}" data-toggle="modal" data-target="#VehicleEditModal">`,
                        `<i class="fas fa-edit"></i> ${l('Edit')}`,
                        '</button>',
                        `<button type="button" class="btn btn-sm btn-danger delete-vehicle" data-vehicle-id="${row.id}" data-vehicle-plate="${row.plateNumber}">`,
                        `<i class="fas fa-trash"></i> ${l('Delete')}`,
                        '</button>'
                    ].join('');
                }
            }
        ]
    }); 


    _$form.validate();

    _$form.find('.save-button').on('click', (e) => {
        e.preventDefault();

        if (!_$form.valid()) {
            return;
        }

        var vehicle = _$form.serializeFormToObject();

        abp.ui.setBusy(_$modal);
        _vehicleService.create(vehicle).done(function () {
            _$modal.modal('hide');
            _$form[0].reset();
            abp.notify.info(l('SavedSuccessfully'));
            _$vehiclesTable.ajax.reload();
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
    });

    $(document).on('click', '.delete-vehicle', function () {
        var vehicleId = $(this).attr("data-vehicle-id");
        var plateNumber = $(this).attr("data-vehicle-plate");

        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                plateNumber),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _vehicleService.delete({ id: vehicleId }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        _$vehiclesTable.ajax.reload();
                    });
                }
            }
        );
    });

    $(document).on('click', '.edit-vehicle', function (e) {
        var vehicleId = $(this).data('vehicle-id');
        e.preventDefault();

        abp.ajax({
            url: abp.appPath + 'Vehicles/EditModal?vehicleId=' + vehicleId,
            type: 'POST',
            dataType: 'html',
            success: function (content) {
                $('#VehicleEditModal .modal-content').html(content);
            }
        });
    });

    $(document).on('click', 'a[data-target="#VehicleCreateModal"]', () => {
        $('.nav-tabs a[href="#vehicle-details"]').tab('show');
    });

    abp.event.on('vehicle.edited', () => {
        _$vehiclesTable.ajax.reload();
    });

    _$modal.on('shown.bs.modal', () => {
        _$modal.find('input:not([type=hidden]):first').focus();
    }).on('hidden.bs.modal', () => {
        _$form.clearForm();
    });

    $('.btn-search').on('click', () => {
        _$vehiclesTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which === 13) {
            _$vehiclesTable.ajax.reload();
            return false;
        }
    });
   
})(jQuery);
