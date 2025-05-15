(function ($) {
    var _mechanicService = abp.services.app.mechanic,
        l = abp.localization.getSource('Invoice'),
        _$modal = $('#MechanicCreateModal'),
        _$form = _$modal.find('form'),
        _$table = $('#MechanicTable');


    var _$mechanicTable = _$table.DataTable({
        paging: true,
        serverSide: true,
        processing: true,
        listAction: {
            ajaxFunction: _mechanicService.getAll,
            inputFilter: function () {
                return $('#MechanicSearchForm').serializeFormToObject(true);
            }
        },
        buttons: [
            {
                name: 'refresh',
                text: '<i class="fas fa-sync-alt"></i>',
                action: () => _$mechanicTable.draw(false)
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
                data:'id',
                className: 'control',
                defaultContent: '',
                orderable: false,
            },
            {
                targets: 1,
                data: 'fullName',
                orderable: false,
            },
            {
                targets: 2,
                data:'phoneNumber',
            },
            {
                targets: 3,
                data:'specialization',
            },
            {
                targets: 4,
                data:'hireDate',
            },
            {
                targets: 5,
                data:'email',
            },
            {
                targets: 6,
                data:'address',
            },
            {
                targets: 7,
                data: null,
                orderable: false,
                autoWidth: false,
                defaultContent: '',
                render: (data, type, row, meta) => {
                    return [
                        `  <button type="button" class="btn btn-sm btn-secondary edit-mechanic" data-mechanic-id="${row.id}" data-toggle="modal" data-target="#VehicleEditModal">`,
                        `      <i class="fas fa-pencil-alt"></i> ${l('Edit')}`,
                        '   </button>',
                        `   <button type="button" class="btn btn-sm btn-danger delete-mechanic" data-mechanic-id="${row.id}" data-mechanic-name="${row.fullName}">`,
                        `     <i class="fas fa-trash"></i> ${l('Delete')}`,
                        '  </button>'
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

        var mechanic = _$form.serializeFormToObject();

        abp.ui.setBusy(_$modal);
        _mechanicService.create(mechanic).done(function () {
            _$modal.modal('hide');
            _$form[0].reset();
            abp.notify.info(l('SavedSuccessfully'));
            _$mechanicTable.ajax.reload();
        }).always(function () {
            abp.ui.clearBusy(_$modal);
        });
    });

    $(document).on('click', '.delete-mechanic', function () {
        var mechanicId = $(this).attr("data-mechanic-id");
        var mechanicName = $(this).attr("data-mechanic-name");

        abp.message.confirm(
            abp.utils.formatString(
                l('AreYouSureWantToDelete'),
                mechanicName),
            null,
            (isConfirmed) => {
                if (isConfirmed) {
                    _mechanicService.delete({ id: mechanicId }).done(() => {
                        abp.notify.info(l('SuccessfullyDeleted'));
                        _$mechanicTable.ajax.reload();
                    });
                }
            }
        );
    });

    $(document).on('click', '.edit-vehicle', function (e) {
        var vehicleId = $(this).data('mechanic-id');
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

    $(document).on('click', '[data-target="#MechanicCreateModal"]', () => {
        $('.nav-tabs a[href="#vehicle-details"]').tab('show');
    });

    abp.event.on('vehicle.edited', () => {
        _$mechanicTable.ajax.reload();
    });

    _$modal.on('shown.bs.modal', () => {
        _$modal.find('input:not([type=hidden]):first').focus();
    }).on('hidden.bs.modal', () => {
        _$form.clearForm();
    });

    $('.btn-search').on('click', () => {
        _$mechanicTable.ajax.reload();
    });

    $('.txt-search').on('keypress', (e) => {
        if (e.which === 13) {
            _$mechanicTable.ajax.reload();
            return false;
        }
    });
   
})(jQuery);
