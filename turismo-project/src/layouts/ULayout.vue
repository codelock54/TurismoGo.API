<template>
  <div class="q-pa">
    <q-layout view="lHh Lpr lff" container style="height: 100vh" class="shadow-2 rounded-borders">
      <q-header elevated class="bg-8">
        <q-toolbar>
          <q-toolbar-title></q-toolbar-title>
          <q-btn label="regresar" flat @click="regresarE" icon="keyboard_arrow_left" />
        </q-toolbar>
      </q-header>

      <q-drawer
        v-model="drawer"
        show-if-above
        :width="350"
        :breakpoint="400"
      >
        <q-scroll-area style="height: calc(100% - 150px); margin-top: 150px; border-right: 1px solid #ddd">
          <q-list padding>
            <q-item clickable v-ripple @click="navigateTo('perfil2/perfilU')">
              <q-item-section avatar>
                <q-icon name="person" />
              </q-item-section>

              <q-item-section>
                Perfil
              </q-item-section>
            </q-item>

            <q-item clickable v-ripple @click="navigateTo('perfil2/actividadesU')">
              <q-item-section avatar>
                <q-icon name="star" />
              </q-item-section>

              <q-item-section>
                Mis actividades
              </q-item-section>
            </q-item>

            <q-item clickable v-ripple @click="navigateTo('reseña')">
              <q-item-section avatar>
                <q-icon name="rate_review" />
              </q-item-section>

              <q-item-section>
                Escribir reseña
              </q-item-section>
            </q-item>

            <q-item clickable v-ripple>
              <q-item-section avatar>
                <q-icon name="settings" />
              </q-item-section>

              <q-item-section>
                Opciones
              </q-item-section>
            </q-item>
          </q-list>
        </q-scroll-area>

        <q-img class="absolute-top" src="https://cdn.quasar.dev/img/material.png" style="height: 150px">
          <div class="absolute-bottom bg-transparent">
            <q-avatar size="56px" class="q-mb-sm">
              <img src="https://cdn.quasar.dev/img/boy-avatar.png">
            </q-avatar>
            <div class="text-weight-bold">Razvan Stoenescu</div>
            <div>@rstoenescu</div>
          </div>
        </q-img>
      </q-drawer>

      <q-page-container>
        <router-view />
      </q-page-container>
    </q-layout>
  </div>
</template>

<script>
import { ref } from 'vue'

export default {
  methods: {
    regresarE(){
      this.$router.push("/principalU")
    },
    navigateTo(page) {
      this.$router.push(`/${page}`)
    }
  },
  setup () {
    return {
      drawer: ref(false)
    }
  }
}
</script>
