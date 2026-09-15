const blogList = document.querySelector("#blog-list");
const blogStatus = document.querySelector("#blog-status");

fetch("assets/Blogs.json")
    .then(response => response.json())
    .then(blogs => {
        blogStatus.textContent = "";

        blogs.forEach(blog => {
            const item = document.createElement("li");
            const article = document.createElement("article");
            const title = document.createElement("h2");
            const date = document.createElement("time");
            const text = document.createElement("p");

            title.textContent = blog.title;
            date.textContent = blog.date;
            date.dateTime = blog.date;
            text.textContent = blog.text;

            article.appendChild(title);
            article.appendChild(date);
            article.appendChild(text);

            if (blog.sources && blog.sources.length > 0) {
                const details = document.createElement("details");
                const summary = document.createElement("summary");
                details.className = "blog-sources";
                summary.textContent = "Bronnen bekijken";
                details.appendChild(summary);

                blog.sources.forEach(source => {
                    const paragraph = document.createElement("p");
                    const link = document.createElement("a");
                    link.textContent = source.title;
                    link.href = source.url;
                    link.className = "blog-source";
                    paragraph.appendChild(link);
                    details.appendChild(paragraph);
                });

                article.appendChild(details);
            }

            item.appendChild(article);
            blogList.appendChild(item);
        });
    });
