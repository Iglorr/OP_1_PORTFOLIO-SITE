const wordElement = document.querySelector("#intro-title");
const definition = document.querySelector(".intro-description");

function showWord(data) {
    wordElement.textContent = data.word;
    definition.textContent = data.meaning;
}

function loadWOTD() {
    wordElement.textContent = "";
    definition.textContent = "Woord van de dag laden...";

    fetch("https://wordoftheday.freeapi.me/")
        .then(response => {
            if (!response.ok) {
                throw new Error("De definitie kan niet opgehaald worden.");
            }
            return response.json();
        })
        .then(data => {
            if (typeof data.word !== "string" || typeof data.meaning !== "string") {
                throw new Error("De definitie kan niet opgehaald worden.");
            }
            showWord(data);
        })
        .catch(error => {
            definition.textContent = error.message + " \nJe kan refeshen.. gaat niet helpen denk ik man.";
        });
}

loadWOTD();
