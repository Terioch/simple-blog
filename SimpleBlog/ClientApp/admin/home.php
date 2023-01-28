<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <title>Admin</title>
  <link
    rel="stylesheet"
    href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css"
  />
  <link rel="stylesheet" href="./styles/global.css" /> 
</head>
<body>
  <?php include("../shared/navigation.php"); ?>

  <main class="main">
  <div class="container mt-4">
    <div class="row">
      <div class="col-12">
        <h2>Recent Posts</h2>
        <hr>
      </div>
    </div>
    <ul class="list-group">
      <li class="list-group-item d-flex align-items-start">
        <img src="/img/post1.jpg" class="img-thumbnail mr-3" alt="Post 1">
        <div class="d-flex flex-column">
          <a href="" class="card-link stretched-link">
            <h5 class="card-title">Post 1 Title</h5>
            <p class="card-text">Post 1 excerpt goes here</p>
          </a>
        </div>
      </li>
      <li class="list-group-item d-flex align-items-start">
        <img src="/img/post2.jpg" class="img-thumbnail mr-3" alt="Post 2">
        <div class="d-flex flex-column">
          <a href="" class="card-link stretched-link">
            <h5 class="card-title">Post 2 Title</h5>
            <p class="card-text">Post 2 excerpt goes here</p>
          </a>
        </div>
      </li>
    </ul>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js"></script>
    <script type="module" src="../components/admin/index.js"></script>
</body>
</html>