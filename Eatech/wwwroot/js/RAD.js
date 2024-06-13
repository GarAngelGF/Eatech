document.addEventListener("DOMContentLoaded", function () {
    const tabs = document.querySelectorAll('input[type="radio"][name="tab"]');
    const tabContents = document.querySelectorAll(".tab-content");

    tabs.forEach((tab, index) => {
        tab.addEventListener("change", function () {
            tabContents.forEach((content, contentIndex) => {
                if (index === contentIndex) {
                    content.style.display = "block";
                } else {
                    content.style.display = "none";
                }
            });
        });
    });
});
