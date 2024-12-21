// Smooth fade-in on page load
$(document).ready(function () {
    $('body').addClass('fade-in');
});
document.getElementById('newsletter-form').addEventListener('submit', function (e) {
    e.preventDefault();

    var email = document.getElementById('email').value;
    var messageDiv = document.getElementById('message');

    fetch('/Newsletter/Subscribe', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({ email: email })
    })
    .then(response => response.json())
    .then(data => {
        if (data.success) {
            messageDiv.textContent = data.message;
            messageDiv.style.color = 'green';
        } else {
            messageDiv.textContent = data.message;
            messageDiv.style.color = 'red';
        }
    })
    .catch((error) => {
        messageDiv.textContent = 'There was an error. Please try again later.';
        messageDiv.style.color = 'red';
    });
});
