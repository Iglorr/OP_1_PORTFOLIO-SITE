const wordElement = document.querySelector("#intro-title");
const definition = document.querySelector(".intro-description");
const WordListUrl = "https://raw.githubusercontent.com/meetDeveloper/freeDictionaryAPI/master/meta/wordList/english.txt";

fetch(WordListUrl)
    .then(response => {
        if (!response.ok) {
            throw new Error("Network response was not ok");
        }
        return response.text();
    })

        .then(text => {
        const words = text.trim().split("\n");

        const index = Math.floor(Math.random() * words.length);
        const word = words[index].trim();

        wordElement.textContent = word;

        return fetch(
            "https://api.dictionaryapi.dev/api/v2/entries/en/"
            + encodeURIComponent(word)
        );
    })
    .then(response => {
        if (!response.ok) {
            throw new Error("De definitie kan niet opgehaald worden.");
        }

        return response.json();
    })
    .then(data => {
        definition.textContent =
            data[0].meanings[0].definitions[0].definition;
    })
    .catch(error => {
        definition.textContent =
            error.message + " Je kan refeshen.. gaat niet helpen denk ik man.";
    });