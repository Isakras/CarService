(function ($) {
    // var _vehicleService = Abp.services.app.vehicle; // adjust if your service is differently named
    var l = abp.localization.getSource('Invoice');

    $(function () {
        $('.delete-holiday-btn').on('click', function () {
            var id = $(this).data('id');

            abp.message.confirm(
                'A jeni i sigurt që doni ta fshini këtë diagnoze?', // Confirmation text
                'Fshirja e Diagozes', // Title
                function (isConfirmed) {
                    if (isConfirmed) {
                        abp.ajax({
                            url: '/VehiclesDiagnosis/Delete?id=' + encodeURIComponent(id),
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

