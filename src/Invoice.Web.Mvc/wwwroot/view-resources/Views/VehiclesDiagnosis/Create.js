(function ($) {
   // var _vehicleService = Abp.services.app.vehicle; // adjust if your service is differently named
    var l = abp.localization.getSource('Invoice'); // replace with your source name

    $(function () {
        $('#searchVinBtn').on('click', function () {
            var vin = $('#vinInput').val();

            if (!vin) {
                $('#vinStatus').text('Please enter a VIN.').css('color', 'red');
                return;
            }

            abp.ui.setBusy('body');

            abp.ajax({
                url: abp.appPath + 'VehiclesDiagnosis/GetByVin?vin=' + encodeURIComponent(vin),
                type: 'GET',
                success: function (data) {
                    if (data && data.vehicleId) {
                        $('#VehicleId').val(data.vehicleId);
                        $('#modelInput').val(data.model);
                        $('#markInput').val(data.mark);
                        $('#plateNoInput').val(data.plateNo);
                        $('#vinStatus').text('Vehicle found and ID set.').css('color', 'green');
                    } else {
                        $('#vinStatus').text('Vehicle not found.').css('color', 'red');
                    }
                 },
                error: function () { 
                        $('#vinStatus').text('Vehicle not found').removeClass('text-success').addClass('text-danger');
                        $('#markInput').val('');
                        $('#modelInput').val('');
                        $('#plateNoInput').val('');
                        $('input[name="VehicleId"]').val('');
                },
                complete: function () {
                    abp.ui.clearBusy('body');
                }
            });
        });
    });
})(jQuery);