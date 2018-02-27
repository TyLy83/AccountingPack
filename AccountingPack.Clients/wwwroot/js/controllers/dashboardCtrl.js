var business = {
    load: function () {
        $('.btn').click(function (e) {
            e.preventDefault();
            var url = $(this).data('url');

            if (typeof url !== 'undefined') {
                $('#admin-area').load(url);
            }
        })
    },
    submit: function () {
        var form = $('#business');
        var url = form.attr('action');
        var btn = $('.btn-create');
        btn.click(function (e) {
            e.preventDefault();
            $.post(url, form.serialize()).done(function (data) {
                if (!data.success)
                    $('#admin-area').html(data.view);
                else
                    $('#admin-area').load(data.redirect);
            })
        })
    }
}

var dashboardCtrl = {
    createBusiness: function () {

    }
}