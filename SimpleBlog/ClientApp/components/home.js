class Home {
  constructor() {
    this.onInit();
  }

  async onInit() {
    const posts = await this.getPosts();
    this.setPostContent(posts);
  }

  async getPosts() {
    const response = await fetch("https://localhost:7133/api/post");
    const posts = await response.json();
    console.log(posts);
    return posts;
  }

  setPostContent(posts) {
    const container = document.getElementById("postsContainer");

    for (const post of posts) {
      const html = `<a href="/post.php?id=${post.id}" class="col col-md-3 border p-3">
        <h2>${post.title}</h2>
        <p>${post.excerpt}</p>
      </a>`;

      container.insertAdjacentHTML("beforeend", html);
    }
  }
}

new Home();
