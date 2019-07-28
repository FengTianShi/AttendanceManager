<template>
  <v-app>
    <div v-if="false">
      <v-navigation-drawer v-model="drawer" app clipped>
        <v-list dense>
          <v-list-item>
            <v-list-item-action>
              <v-icon>dashboard</v-icon>
            </v-list-item-action>
            <v-list-item-content>
              <v-list-item-title>Dashboard</v-list-item-title>
            </v-list-item-content>
          </v-list-item>
          <v-list-item>
            <v-list-item-action>
              <v-icon>settings</v-icon>
            </v-list-item-action>
            <v-list-item-content>
              <v-list-item-title>Settings</v-list-item-title>
            </v-list-item-content>
          </v-list-item>
        </v-list>
      </v-navigation-drawer>

      <v-app-bar app clipped-left>
        <v-app-bar-nav-icon @click.stop="drawer = !drawer"></v-app-bar-nav-icon>
        <v-toolbar-title>Application</v-toolbar-title>
      </v-app-bar>
    </div>

    <v-layout align-center justify-center>
      <Canvas />
      <v-flex xs10 sm8 md4>
        <v-card class="elevation-12">
          <v-toolbar dark flat>
            <v-toolbar-title>
              <v-icon>event_available</v-icon>&nbsp;Welcome to Attendance Manager&trade;
            </v-toolbar-title>
            <v-spacer></v-spacer>
          </v-toolbar>
          <v-card-text>
            <v-text-field label="Mail Address" prepend-icon="person" type="text"></v-text-field>
            <v-text-field label="Password" prepend-icon="lock" type="password"></v-text-field>
          </v-card-text>
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn color="teal">Sign up</v-btn>
            <v-btn color="red">Sign in</v-btn>
          </v-card-actions>
        </v-card>
      </v-flex>
    </v-layout>

    <div v-if="false">
      <v-footer app>
        <span>&copy; 2019</span>
      </v-footer>
    </div>
  </v-app>
</template>

<script lang="ts">
import Vue from "vue";
import Canvas from "./components/Canvas.vue";

export default Vue.extend({
  name: "App",
  components: {
    Canvas
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
