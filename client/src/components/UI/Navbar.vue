<template>
    <nav class="navbar navbar-expand-lg app-navbar">
        <a class="navbar-brand" href="#">App</a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
            <span class="navbar-toggler-icon"></span>
        </button>
        <div class="collapse navbar-collapse" id="navbarNav">
            <ul class="navbar-nav ml-auto">
                <li class="nav-item">
                    <a class="nav-link" href="#">Login</a>
                </li>
                <li class="nav-item">
                    <a class="nav-link" href="#">Register</a>
                </li>
                
            </ul>
        </div>
    </nav>
</template>

<script>
    export default {
        name: "Navbar"
    };
</script>

<style scoped>
    .app-navbar {
        background-color: blue;
        width: 100%;
    }

    a {
        color: #fff !important;
    }
</style>
