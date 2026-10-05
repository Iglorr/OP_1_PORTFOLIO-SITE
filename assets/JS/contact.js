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

                form.addEventListener("submit", (event) => {
                    event.preventDefault();
                });
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