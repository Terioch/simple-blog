class NewPost {
  constructor() {
    this.onInit();
  }

  onInit() {
    document
      .getElementById("newPostForm")
      .addEventListener("submit", this.newPost);
  }

  async newPost(e) {
    e.preventDefault();
    console.log(e.target);

    const title = e.target["titleInput"].value;
    const excerpt = e.target["excerptInput"].value;
    const content = e.target["contentInput"].value;
    const image = e.target["imageInput"].files[0];

    const postDto = {
      title,
      excerpt,
      content,
    };

    console.log(postDto);
    console.log(image);

    const formData = new FormData();

    for (const key in postDto) {
      formData.append(key, postDto[key]);
    }

    formData.append("image", image, image.name);

    // formData.append("title", postDto.title);
    // formData.append("excerpt", postDto.excerpt);
    // formData.append("content", postDto.content);

    const response = await fetch("https://localhost:7133/api/post/create", {
      method: "POST",
      body: formData,
    });

    const result = await response.json();
    console.log(result);
  }
}

new NewPost();
