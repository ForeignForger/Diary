Diary = function (mode, container) {
    var settings = {
        viewMode: mode,
        container: container,
        url: "Diary/GetDiaryContent"
    }

    function init() {
        $.ajax({
            url: settings.url,
            data: {
                mode: settings.viewMode
            },
            type: "GET",
            success: function (response) {
                loadDiaryContent(response)
            }
        });
    }

    function loadDiaryContent(html) {
        $("." + settings.container).html(html);
    }

    return {
        init: init
    };
};