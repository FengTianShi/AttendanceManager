<template>
  <v-app>
    <MyHeader />
    <router-view />
    <MyFooter />
  </v-app>
</template>

<script lang="ts">
import Vue from "vue";
import MyHeader from "./components/MyHeader.vue";
import MyFooter from "./components/MyFooter.vue";

export default Vue.extend({
  name: "App",
  components: {
    MyHeader,
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


