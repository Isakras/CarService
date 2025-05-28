(function ($) {
    var _mechanicService = abp.services.app.mechanic,
        l = abp.localization.getSource('Invoice'),
        _$modal = $('#MechanicEditModal'),
        _$form = _$modal.find('form');

    function save() {
        if (!_$form.valid()) {
            return;
        }

        var mechanic = _$form.serializeFormToObject();
     
        abp.ui.setBusy(_$form);
        _mechanicService.updateMechanic(mechanic).done(function () {
            abp.ui.clearBusy(_$form);
            _$modal.modal('hide');
            abp.notify.info(l('SavedSuccessfully'));
            abp.event.trigger('user.edited', mechanic);
        }).always(function () {
            abp.ui.clearBusy(_$form);
        });
    }

    _$form.closest('div.modal-content').find(".save-button").click(function (e) {
        e.preventDefault();
        save();
    });

    _$form.find('input').on('keypress', function (e) {
        if (e.which === 13) {
            e.preventDefault();
            save();
        }
    });

    _$modal.on('shown.bs.modal', function () {
        _$form.find('input[type=text]:first').focus();
    });
})(jQuery);
