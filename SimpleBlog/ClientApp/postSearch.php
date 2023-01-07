<!DOCTYPE html>
<html lang="en">
<head>
  <meta charset="UTF-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="viewport" content="width=device-width, initial-scale=1.0">
  <title>Post Search</title>
  <link
    rel="stylesheet"
    href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css"
  />
  <link
    href="./styles/global.css"
    rel="stylesheet"
  />
</head>
<body>
  <main class="main">
    <?php include('./shared/navigation.php'); ?>              

    <div class="container mt-5 mx-auto w-100">
      <div id="postsContainer" class="row d-flex justify-center">
        <div class="d-flex align-items-center mb-5">
          <h1 id="searchResults" class="me-3 mb-0">0 results</h1>
          <form id="postSearchForm" class="me-3">
            <div class="input-group">
                <span class="input-group-text">
                    <span class="material-icons">search</span>
                </span>
                <input id="searchInput" type="text" class="form-control" placeholder="Search" aria-label="Search">
            </div>  
          </form>   
        </div>
        <!-- Posts html added in JS file -->
      </div>
    </div>
  </main>

    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js"></script>
    <script src="./components/postSearch.js"></script>
</body>
</html>