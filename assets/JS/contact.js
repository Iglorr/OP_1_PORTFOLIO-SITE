function validateName(form) {
    const nameInput = form.querySelector("#first-name");
    const nameError = form.querySelector("#first-name-error");

    if (nameInput.value.trim() === "") {
        nameError.textContent = "Vul je naam in.";
        nameInput.setAttribute("aria-invalid", "true");
        return false;
    }

    nameError.textContent = "";
    nameInput.setAttribute("aria-invalid", "false");
    return true;
}

function validateLastName(form) {
    const lastNameInput = form.querySelector("#last-name");
    const lastNameError = form.querySelector("#last-name-error");

    if (lastNameInput.value.trim() === "") {
        lastNameError.textContent = "Vul je achternaam in.";
        lastNameInput.setAttribute("aria-invalid", "true");
        return false;
    }

    lastNameError.textContent = "";
    lastNameInput.setAttribute("aria-invalid", "false");
    return true;
}

function validateEmail(form) {
    const emailInput = form.querySelector("#email");
    const emailError = form.querySelector("#email-error");

    if (emailInput.value.trim() === "") {
        emailError.textContent = "Vul je e-mailadres in.";
        emailInput.setAttribute("aria-invalid", "true");
        return false;
    }

    // type="email" laat de browser controleren of het formaat klopt.
    if (emailInput.validity.typeMismatch) {
        emailError.textContent = "Vul een geldig e-mailadres in, bijvoorbeeld naam@voorbeeld.nl.";
        emailInput.setAttribute("aria-invalid", "true");
        return false;
    }

    emailError.textContent = "";
    emailInput.setAttribute("aria-invalid", "false");
    return true;
}

function setupContactValidation(form) {
    const nameInput = form.querySelector("#first-name");
    const lastNameInput = form.querySelector("#last-name");
    const emailInput = form.querySelector("#email");

    form.addEventListener("submit", (event) => {
        event.preventDefault();

        // Controleer alle drie, zodat alle foutmeldingen tegelijk verschijnen.
        const nameValid = validateName(form);
        const lastNameValid = validateLastName(form);
        const emailValid = validateEmail(form);

        if (nameValid === false) {
            nameInput.focus();
        } else if (lastNameValid === false) {
            lastNameInput.focus();
        } else if (emailValid === false) {
            emailInput.focus();
        }
    });

    nameInput.addEventListener("input", () => {
        validateName(form);
    });
    lastNameInput.addEventListener("input", () => {
        validateLastName(form);
    });
    emailInput.addEventListener("input", () => {
        validateEmail(form);
    });
}

const contactLink = document.querySelector(".contact-link");

function ContactDialogsetup() {
    const dialog = document.createElement("dialog");
    dialog.className = "contact-dialog";
    dialog.setAttribute("aria-label", "Contactformulier");

    const content = document.createElement("section");
    content.className = "contact-dialog-content";
    const loadStatus = document.createElement("p");
    loadStatus.setAttribute("role", "status");

    content.appendChild(loadStatus);
    dialog.appendChild(content);
    document.body.appendChild(dialog);

    const openButton = document.createElement("button");
    openButton.type = "button";
    openButton.className = "contact-link";
    openButton.textContent = "Contact";
    openButton.setAttribute("aria-haspopup", "dialog");
    contactLink.replaceWith(openButton);

    function openDialog() {
        dialog.showModal();
        document.body.classList.add("contact-open");
    }

    function loadContactForm() {
        content.replaceChildren(loadStatus);
        loadStatus.textContent = "Contactformulier laden…";

        fetch("contact.html")
            .then(response => response.text())
            .then(html => {
                const parser = new DOMParser();
                const page = parser.parseFromString(html, "text/html");
                const section = page.querySelector(".contact-page section");
                const form = page.querySelector(".contact-form");

                setupContactValidation(form);
                content.replaceChildren(section);
                
                const closeButton = dialog.querySelector(".contact-close");
                closeButton.addEventListener("click", () => {
                    dialog.close();
                });
                openDialog();
            });
    }

    openButton.addEventListener("click", () => {
        loadContactForm();
    });

    dialog.addEventListener("cancel", (event) => {
        event.preventDefault();
    });

    dialog.addEventListener("close", () => {
        document.body.classList.remove("contact-open");
        openButton.focus();
    });
}

ContactDialogsetup();

const pageForm = document.querySelector(".contact-form");
if (pageForm) {
    setupContactValidation(pageForm);
}
