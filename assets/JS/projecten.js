const projectList = document.querySelector("#project-list");
const projectImage = document.querySelector("#project-image");
const placeholder = document.querySelector("#project-placeholder");

const personalButton = document.querySelector("#filter-personal");
const schoolButton = document.querySelector("#filter-school");
const filterStatus = document.querySelector("#filter-status");

fetch("assets/JSON/Projecten.json")
    .then(response => response.json())
    .then(projects => {
        function showProjects(category) {
            // Maak de lijst leeg voordat de gekozen categorie wordt getoond.
            projectList.textContent = "";
            projectImage.hidden = true;
            projectImage.removeAttribute("src");
            placeholder.hidden = false;
            placeholder.textContent = "kies ff een projectje";
            filterStatus.textContent = "Je bekijkt " + category + " projecten.";

            projects.forEach(project => {
                if (project.category === category) {
                    const item = document.createElement("li");
                    const article = document.createElement("article");
                    const title = document.createElement("h3");
                    const button = document.createElement("button");
                    const text = document.createElement("p");
        
                    button.type = "button";
                    button.textContent = project.title;
                    text.textContent = project.text;
        
                    title.appendChild(button);
                    article.appendChild(title);
                    article.appendChild(text);
                    item.appendChild(article);
                    projectList.appendChild(item);
        
                    article.addEventListener("click", () => {
                        projectImage.hidden = true;
                        projectImage.removeAttribute("src");
                        placeholder.hidden = false;
        
                        if (project.image) {
                            placeholder.textContent = "Afbeelding laden…";
                            projectImage.alt = project.alt;
                            projectImage.src = project.image;
                        } else {
                            placeholder.textContent = "Meneer heeft nog geen afbeelding voor: " + project.title;
                        }
                    });
                }
            });
        }

        personalButton.addEventListener("click", () => {
            showProjects("personal");
        });

        schoolButton.addEventListener("click", () => {
            showProjects("school");
        });

        showProjects("personal");
    });

projectImage.addEventListener("load", () => {
    projectImage.hidden = false;
    placeholder.hidden = true;
});

