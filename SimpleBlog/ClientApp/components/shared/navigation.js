class Navigation {
  constructor() {
    this.onInit();
  }

  onInit() {
    console.log("OnInit");
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
    console.log(e.target);
    const userName = e.target["registerUserNameInput"].value;
    const email = e.target["registerEmailInput"].value;
    const password = e.target["registerPasswordInput"].value;

    const userDto = {
      userName,
      email,
      password,
    };
    console.log(userDto);
    const response = await fetch(`https://localhost:7133/api/auth/register`, {
      method: "POST",
      body: JSON.stringify(userDto),
      headers: { "Content-Type": "application/json" },
    });

    const result = await response.json();
    console.log(result);
  }
}

new Navigation();
