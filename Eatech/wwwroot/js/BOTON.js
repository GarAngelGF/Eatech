document.addEventListener('DOMContentLoaded', function() {
    document.querySelector('.animated-button').addEventListener('click', function() {
        var url = document.getElementById('redirectLink').getAttribute('href');
        if (url) {
            window.location.href = url;
        }
    });
});