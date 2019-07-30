<template>
  <div>
    <v-navigation-drawer v-if="isShowMenu" v-model="isOpenMenu" app clipped>
      <v-list dense>
        <v-list-item>
          <v-list-item-action>
            <v-icon>dashboard</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>ServiceA</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
        <v-list-item>
          <v-list-item-action>
            <v-icon>dashboard</v-icon>
          </v-list-item-action>
          <v-list-item-content>
            <v-list-item-title>ServiceB</v-list-item-title>
          </v-list-item-content>
        </v-list-item>
      </v-list>
    </v-navigation-drawer>

    <v-app-bar app prominent clipped-left src="https://picsum.photos/1920/1080?random">
      <v-app-bar-nav-icon v-if="isShowMenu" @click.stop="isOpenMenu = !isOpenMenu"></v-app-bar-nav-icon>
      <v-toolbar-title>
        <v-icon>event_available</v-icon>&nbsp;Attendance Manager&trade;
      </v-toolbar-title>
      <v-spacer></v-spacer>
    </v-app-bar>
  </div>
</template>

<script lang="ts">
import Vue from "vue";

export default Vue.extend({
  data: () => ({
    isOpenMenu: false,
    isShowMenu: true
  })
});
</script>