const introLabel = document.querySelector(".intro-label");
const introTitle = document.querySelector("#intro-title");
const introDescription = document.querySelector(".intro-description");
const introCaption = document.querySelector(".intro-placeholder figcaption");
const introNext = document.querySelector(".intro-next");

fetch("assets/JSON/Intro.json")
    .then(response => response.json())
    .then(cards => {
        let currentCard = 0;

        function showCard() {
            const card = cards[currentCard];

            introLabel.textContent = card.label;
            introTitle.textContent = card.title;
            introDescription.textContent = card.text;
            introCaption.textContent = card.caption;
        }

        showCard();
        introNext.hidden = cards.length < 2;
        introNext.addEventListener("click", () => {
            currentCard = (currentCard + 1) % cards.length;
            showCard();
        });
    });
