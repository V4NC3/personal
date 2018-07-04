<template>
    <div class='row'>
        <User></User>
        <FriendList></FriendList>
    </div>
</template>

<script>
    import User from './User/User';
    import FriendList from './Friends/FriendList.vue';

    export default {
        name: 'Home',
        components: { User, FriendList }
    }   
</script>

<style scoped>

</style>
