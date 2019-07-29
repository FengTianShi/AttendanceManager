<template>
  <v-app>
    <MyHeader />
    <Login />
    <MyFooter />
  </v-app>
</template>

<script lang="ts">
import Vue from "vue";
import MyHeader from "./components/MyHeader.vue";
import MyFooter from "./components/MyFooter.vue";
import Login from "./components/Login.vue";

export default Vue.extend({
  name: "App",
  components: {
    MyHeader,
    Login,
    MyFooter
  },
  data: () => ({
    drawer: false
  }),
  created() {
    // @ts-ignore
    this.$vuetify.theme.dark = true;
  }
});
</script>
