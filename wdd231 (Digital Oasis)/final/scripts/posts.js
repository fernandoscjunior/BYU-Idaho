const posts = "data/posts.json";

const cards = document.querySelector('#cards');

//Consuming my json asynchronously
async function getPosts() {
    try {
        const response = await fetch(posts);
        if (response.ok) {
            const data = await response.json();
            displayPosts(data.posts);
        } else {
            throw Error(await response.text());
        }
    } catch (error) {
        console.log(error);
    }
}

const displayPosts = (posts) => {
    posts.forEach((post) => {
        let card = document.createElement('section');
        let title = document.createElement('h2');
        let content = document.createElement('p');
        let author = document.createElement('p');
        let date = document.createElement('p');
        let image = document.createElement('img');

        title.textContent = `${post.title}`;
        content.textContent = `${post.content}`;
        author.textContent = `Author: ${post.author}`;
        date.textContent = `Published: ${post.date}`;

        image.setAttribute('src', post.image);
        image.setAttribute('alt', `A image to support ${post.title} post's idea.`);
        image.setAttribute('loading', 'lazy');
        image.setAttribute('width', '340');
        image.setAttribute('height', '440');

        card.appendChild(title);
        card.appendChild(author);
        card.appendChild(image);
        card.appendChild(content);
        card.appendChild(date);
        cards.appendChild(card);
    }); 
}

getPosts();