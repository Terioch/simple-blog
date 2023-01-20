class Post {
  constructor() {
    this.onInit();
  }

  async onInit() {
    const id = window.location.href.split("?")[1].split("=")[1];
    const post = await this.getPost(id);
    console.log(post);
    this.setPostContent(post);
  }

  async getPost(id) {
    const response = await fetch(`https://localhost:7133/api/post/${id}`);
    console.log(response);
    const post = await response.json();
    return post;
  }

  setPostContent(post) {
    const container = document.getElementById("postContainer");
    const html = `<div class="mx-auto" style="max-width: 700px">
      <h1 class="mb-3">${post.title}</h1>
      <p>${post.excerpt}</p>
    </div>`;

    container.insertAdjacentHTML("afterbegin", html);
  }
}

new Post();
