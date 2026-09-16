const projectList = document.querySelector("#project-list");
const projectImage = document.querySelector("#project-image");
const placeholder = document.querySelector("#project-placeholder");

fetch("assets/JSON/Projecten.json")
    .then(response => response.json())
    .then(projects => {
        projects.forEach(project => {
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
        });
    });

projectImage.addEventListener("load", () => {
    projectImage.hidden = false;
    placeholder.hidden = true;
});

