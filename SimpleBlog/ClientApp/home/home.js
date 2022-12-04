class Home {
  constructor() {
    this.onInit();
  }

  async onInit() {
    console.log("Initialized");
    const posts = await this.getPosts();
    console.log(posts);
    this.setPostContent(posts);
  }

  async getPosts() {
    const response = await fetch("https://localhost:7256/post");
    console.log(response);
    const posts = await response.json();
    return posts;
  }

  setPostContent(posts) {
    const container = document.getElementById("postsContainer");

    for (const post of posts) {
      const html = `<a href="/post/post.html?id=${post.id}" class="col col-md-3 border p-3">
        <h2>${post.title}</h2>
        <p>${post.excerpt}</p>
      </a>`;

      container.insertAdjacentHTML("beforeend", html);
    }
  }
}

new Home();
