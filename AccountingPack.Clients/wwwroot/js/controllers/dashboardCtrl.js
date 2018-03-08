// dashboard js controllers
var dashboardCtrl = {
    load: function () {
        var adminArea = $('#admin-area');
        var btnItems = $('.btn-item');
        var apForm = $('.ap-form');
        $.each(btnItems, function (index, btn) {
            $(btn).click(function (e) {
                e.preventDefault();
                var url = $(this).data('url');
                if (typeof url !== 'undefined') {
                    adminArea.load(url, function () {
                        dashboardCtrl.load();
                        dashboardCtrl.submit();
                        dashboardCtrl.depreciation();
                    })
                }
            })
        });
    },
    submit: function () {
        var adminArea = $('#admin-area');
        var apForm = $('.ap-form');
        var apSubmit = $('.ap-submit');
        apSubmit.click(function (e) {
            e.preventDefault();
            var url = apForm.attr('action');
            var data = apForm.serialize();
            $.post(url, data).done(function (result) {
                if (!result.success) {
                    adminArea.html(result.view);
                    dashboardCtrl.load();
                    dashboardCtrl.submit();
                    dashboardCtrl.depreciation();
                } else {
                    adminArea.load(result.redirect, function () {
                        dashboardCtrl.load();
                        dashboardCtrl.submit();
                        dashboardCtrl.depreciation();
                    })
                }
            })
        });
    },
    depreciation: function () {
        var depr = $('#depreciation');
        var btnAdd = $('#add-dep');
        var btnRemove = $('#remove-dep');

        btnAdd.click(function (e) {
            e.preventDefault();
            depr.load('/Entities/AddDep', function () {
                dashboardCtrl.depreciation();
            });

        });

        btnRemove.click(function (e) {
            e.preventDefault();
            depr.load('/Entities/RemoveDep', function () {
                dashboardCtrl.depreciation();
            })
        });

    }
}
