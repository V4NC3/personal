<template>
    <div class='col-md-4 col-lg-4'>
        <h1>Friends list</h1>
        <div class='col-md-12 col-lg-12 friend-container'>
            <Friend class='friend-item col-sm-12 col-md-4 col-lg-4' v-for='friend in friends' v-bind:key='friend.id'></Friend>
        </div>
    </div>       
</template>

<script>
    import Friend from './Friend.vue';

    export default {
        name: 'FriendList',
        components: { Friend },
        data() {
            return {
                friends: []
            }
        },
        methods() {  }
    }
</script>

<style scoped>
    .friend-container {
        border: 1px solid black;
        height: auto;
        min-height: 300px;
        width: 100%;
        border-radius: 15px;
    }
</style>
