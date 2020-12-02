DayViewMode = function (diary) {
    this.key = "day-mode";

    var diary = diary;
    var settings = {
        cookies: {
            selectedDate: "selectedDate"
        },
        selectors: {
            actions: ""
        }
    };

    this.init = function() {
        var selectedDate = Cookies.get(settings.cookies.selectedDate);

        if (!selectedDate) {
            var currentDate = new Date();
            Cookies.set(settings.cookies.selectedDate, currentDate.toISOString());
        }
    };

    this.setup = function() {
        //todo all the buttons and stuff
        $(".day-mode .day-actions .day-change-date").click(function () {
            var selectedDate = Cookies.get(settings.cookies.selectedDate);

            if (!selectedDate) {
                selectedDate = new Date();
            } else {
                selectedDate = new Date(selectedDate);
            }

            var days = +($(this).attr("data-value"));

            selectedDate.setDate(selectedDate.getDate() + days);

            Cookies.set(settings.cookies.selectedDate, selectedDate.toISOString());

            diary.loadDiary();
        });
    };
};