<template>
  <v-container>
    <v-layout align-center justify-center>
      <v-flex>
        <v-card>
          <v-card-text>
            <v-layout wrap>
              <v-flex xs12 md6>
                <span>Scheme</span>
                <v-switch v-model="$vuetify.theme.dark" primary label="Dark"></v-switch>
              </v-flex>
              <v-flex xs12 md6>
                <span>Drawer</span>
                <v-radio-group v-model="primaryDrawer.type" column>
                  <v-radio
                    v-for="drawer in drawers"
                    :key="drawer"
                    :label="drawer"
                    :value="drawer.toLowerCase()"
                    primary
                  ></v-radio>
                </v-radio-group>
                <v-switch v-model="primaryDrawer.clipped" label="Clipped" primary></v-switch>
                <v-switch v-model="primaryDrawer.floating" label="Floating" primary></v-switch>
                <v-switch v-model="primaryDrawer.mini" label="Mini" primary></v-switch>
              </v-flex>
              <v-flex xs12 md6>
                <span>Footer</span>
                <v-switch v-model="footer.inset" label="Inset" primary></v-switch>
              </v-flex>
            </v-layout>
          </v-card-text>
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn text>Cancel</v-btn>
            <v-btn text color="primary">Submit</v-btn>
          </v-card-actions>
        </v-card>
      </v-flex>
    </v-layout>
  </v-container>
</template>

<script lang="ts">
import Vue from "vue";

export default Vue.extend({
  data: () => ({
    drawers: ["Default (no property)", "Permanent", "Temporary"],
    primaryDrawer: {
      model: null,
      type: "default (no property)",
      clipped: false,
      floating: false,
      mini: false
    },
    footer: {
      inset: false
    }
  })
});
</script>
