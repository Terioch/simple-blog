class Navigation {
  constructor() {
    this.onInit();
  }

  onInit() {
    document
      .getElementById("postSearchForm")
      .addEventListener("submit", this.searchPosts.bind(this));

    document
      .getElementById("registerForm")
      .addEventListener("submit", this.register.bind(this));
  }

  async searchPosts(e) {
    e.preventDefault();
    window.location.href = `/postSearch.php?search=${e.target["searchInput"].value}`;
  }

  async register(e) {
    e.preventDefault();

    const username = e.target["registerUserNameInput"].value;
    const email = e.target["registerEmailInput"].value;
    const password = e.target["registerPasswordInput"].value;

    const userDto = {
      username,
      email,
      password,
    };

    const response = await fetch("https://localhost:7256/api/auth/register", {
      method: "POST",
      body: JSON.stringify(userDto),
      headers: { "Content-Type": "application/json" },
    });

    const result = await response.json();
    console.log(result);
  }
}

new Navigation();
