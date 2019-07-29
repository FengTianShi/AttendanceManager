<template>
  <v-content>
    <v-container>
      <HomeComp1 />
      <HomeComp2 />
      <HomeComp3 />
      <HomeComp4 />
    </v-container>
  </v-content>
</template>

<script lang="ts">
import Vue from "vue";
import HomeComp1 from "../components/HomeComp1.vue";
import HomeComp2 from "../components/HomeComp2.vue";
import HomeComp3 from "../components/HomeComp3.vue";
import HomeComp4 from "../components/HomeComp4.vue";

export default Vue.extend({
  components: {
    HomeComp1,
    HomeComp2,
    HomeComp3,
    HomeComp4
  }
});
</script>
