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

    document
      .getElementById("loginForm")
      .addEventListener("submit", this.login.bind(this));
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
    this.storeAuthDetails(result.payload);
    this.redirectToHome();
  }

  async login(e) {
    e.preventDefault();

    const email = e.target["loginEmailInput"].value;
    const password = e.target["loginPasswordInput"].value;

    const userDto = {
      email,
      password,
    };
    console.log(userDto);
    const response = await fetch(`https://localhost:7256/api/auth/login`, {
      method: "POST",
      body: JSON.stringify(userDto),
      headers: { "Content-Type": "application/json" },
    });

    const result = await response.json();
    console.log(result);
    this.storeAuthDetails(result.payload);
    this.redirectToHome();
  }

  storeAuthDetails(payload) {
    localStorage.setItem("user-info", JSON.stringify(payload.userDto));
    localStorage.setItem("access-token", JSON.stringify(payload.accessToken));
    localStorage.setItem("expires", JSON.stringify(payload.expires));
  }

  redirectToHome() {
    window.location.href = "/";
  }
}

new Navigation();
