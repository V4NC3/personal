<template>
    <div class='container-fluid'>
        <Navbar></Navbar>
        <router-view />     
        <!-- <Footer></Footer> -->
    </div>
</template>

<script>
import Navbar from './components/UI/Navbar.vue';
import Footer from './components/UI/Footer.vue';

export default {
    name: "App",
    components: {
        Navbar: Navbar,
        Footer: Footer
    }
};
</script>

<style scoped>

</style>
