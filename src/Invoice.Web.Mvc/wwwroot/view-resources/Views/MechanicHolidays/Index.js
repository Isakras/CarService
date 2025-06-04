(function ($) {
    // var _vehicleService = Abp.services.app.vehicle; // adjust if your service is differently named
    var l = abp.localization.getSource('Invoice');

    $(document).ready(function () {
        $('#btnCreateHoliday').click(function () {
            $.ajax({
                url: abp.appPath +'MechanicHolidays/CreateModal',
                type: 'GET',
                success: function (result) {
                    $('#CreateHolidayModalContainer').html(result);
                    $('#MechanicCreateModal').modal('show');
                },
                error: function () {
                    alert('Could not load the modal. Please try again.');
                }
            });
        });
    });

    // Handle Save button click inside modal
    $(document).on('submit', 'form[name="mechanicCreateForm"]', function (e) {
        e.preventDefault(); // Prevent normal form post

        var $form = $(this);
        var data = $form.serialize();

        $.ajax({
            url: abp.appPath +'MechanicHolidays/Create',
            type: 'POST',
            data: data,
            success: function () {
                $('#MechanicCreateModal').modal('hide');
                abp.notify.success('Pushimi u shtua me sukses');
                location.reload();
                // Optionally reload a table or list
            },
            error: function () {
                abp.notify.error('Gabim gjatë ruajtjes së pushimit.');
            }
        });
    });

    // When dropdown changes, update hidden input
    $(document).on('change', '#WorkerSelect', function () {
        var selectedWorkerId = $(this).val();
        $('#MechanicId').val(selectedWorkerId);
    });

    $(function () {
        $('.delete-holiday-btn').on('click', function () {
            var id = $(this).data('id');

            abp.message.confirm(
                'A jeni i sigurt që doni ta fshini këtë pushim?', // Confirmation text
                'Fshirja e Pushimit', // Title
                function (isConfirmed) {
                    if (isConfirmed) {
                        abp.ajax({
                            url: '/MechanicHolidays/Delete?id=' + encodeURIComponent(id),
                            type: 'POST',
                            data: { id: id }, // ✅ This works with ASP.NET's model binder
                            success: function (response) {
                                if (response.success) {
                                    abp.notify.success(response.message);
                                    location.reload();
                                } else {
                                    abp.notify.error("Fshirja dështoi.");
                                }
                            },
                            error: function () {
                                abp.notify.error("Gabim gjatë fshirjes.");
                            }
                        });
                    }
                }
            );
        });
    });

   
}) (jQuery);

