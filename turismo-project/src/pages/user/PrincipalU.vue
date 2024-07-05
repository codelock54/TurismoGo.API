<template>
  <q-layout view="hHh Lpr fFf">
    <q-header elevated style="background-color: #1e88e5;">
      <q-toolbar class="custom-toolbar">
        <q-toolbar-title class="toolbar-title">
          Turismo Go
        </q-toolbar-title>

        <div class="toolbar-buttons">
          <q-btn
            flat
            round
            dense
            icon="home"
            label="Inicio"
            @click="navigateTo('/principalU')"
            class="nav-btn"
            color="white"
          />
          <q-btn
            flat
            round
            dense
            icon="explore"
            label="Actividades"
            @click="navigateTo('/actividades')"
            class="nav-btn"
            color="white"
          />
          <q-btn
            flat
            round
            dense
            icon="person"
            label="Perfil"
            @click="navigateTo('/perfil2/perfilU')"
            class="nav-btn"
            color="white"
          />
          <q-btn
            flat
            round
            dense
            icon="exit_to_app"
            label="Cerrar Sesión"
             @click="confirm = true"
            class="nav-btn"
            color="white"
          />
        </div>
        <q-dialog v-model="confirm" persistent>
      <q-card>
        <q-card-section class="row items-center">
          <span class="q-ml-sm">¿Estas seguro de cerrar sesión?</span>
        </q-card-section>

        <q-card-actions align="right">
          <q-btn flat label="Cancelar" color="primary" v-close-popup />
          <q-btn flat label="Cerrar sesión" color="primary" v-close-popup @click="navigateTo('/')"/>
        </q-card-actions>
      </q-card>
    </q-dialog>
      </q-toolbar>
    </q-header>


    <q-page-container>
               <!-- Hero Section -->
      <section class="hero">
    <div class="hero-content">
        <h1>Comienza la aventura de tus sueños</h1>
        <p>Encuentra la actividad que tanto anhelas realizar, con Turismo Go.</p>
    </div>
</section>
      <div class="custom-padding">
      <div class="message">
      Conoce las actividades que puedes realizar:
    </div>
<q-carousel
      arrows
      animated
      v-model="slide"
      height="350px"
    >
      <q-carousel-slide name="first" img-src="https://www.civitatis.com/f/peru/lima/excursion-ica-huacachina-islas-ballestas-589x392.jpg">
        <div class="absolute-bottom custom-caption">
          <div class="text-h2">Excursión a Ica</div>
          <div class="text-subtitle1">Huacachina</div>
        </div>
      </q-carousel-slide>
      <q-carousel-slide name="second" img-src="https://www.civitatis.com/f/peru/lima/tour-lima-589x392.jpg">
        <div class="absolute-bottom custom-caption">
          <div class="text-h2">Tour por Lima</div>
          <div class="text-subtitle1">Plaza de armas</div>
        </div>
      </q-carousel-slide>
      <q-carousel-slide name="third" img-src="https://www.ohmachupicchu.com/wp-content/uploads/Viaje-en-grupo-a-Machupicchu.jpg">
        <div class="absolute-bottom custom-caption">
          <div class="text-h2">Tour 5 Días Cusco</div>
          <div class="text-subtitle1">Machu Piccchu</div>
        </div>
      </q-carousel-slide>
    </q-carousel>
  </div>
    <!-- Motivational Phrase -->
    <div class="message">
      Recuerda:
    </div>
    <section class="motivacion">
        <p>"El mundo es un libro, y aquellos que no viajan solo leen una página." - San Agustín</p>
    </section>

    </q-page-container>
  </q-layout>
  <footer>
        <p>&copy; 2024 Turismo Go. Todos los derechos reservados.</p>
    </footer>
</template>

<script>
import { ref } from 'vue'
export default {
  setup () {
    return {
      slide: ref('first'),
      confirm: ref(false),
    }
  },
  methods: {
    navigateTo(route) {
      this.$router.push(route);
    },
    logout() {
      // Implementa aquí la lógica para cerrar sesión
      // Por ejemplo, limpiar el token de autenticación y redirigir a la página de inicio de sesión
    }
  }
};
</script>

<style scoped>
.custom-toolbar {
  height: 65px; /* Ajusta esta altura según tus necesidades */
}

.toolbar-title {
  font-size: 25px;
  font-weight: bold;
  color: white;
  padding-left: 15px;
}

.toolbar-buttons {
  display: flex;
  align-items: center;
}

.nav-btn {
  margin-right: 20px; /* Ajusta el margen entre los botones según necesites */
}

/* Estilo para cambiar el color de los botones */
.q-btn-white {
  background-color: #1e88e5;
}



body {
    font-family: Arial, sans-serif;
    margin: 0;
    padding: 0;
    box-sizing: border-box;
}

.hero {
    position: relative;
    height: 75vh;
    background: url('https://travel1tours.com/wp-content/uploads/2019/09/Lugares-turisticos-de-Peru.jpg') no-repeat center center/cover;
    display: flex;
    justify-content: center;
    align-items: center;
    text-align: center;
    color: white;
    overflow: hidden;
}

.hero::before {
    content: '';
    position: absolute;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    background: rgba(0, 0, 0, 0.5);
}

.hero-content {
    position: relative;
    z-index: 1;
}

.hero-content h1 {
    font-size: 4em;
    margin-bottom: 0.5em;
    text-transform: uppercase;
    letter-spacing: 2px;
}

.hero-content p {
    font-size: 1.5em;
    margin-bottom: 0;
}
body {
    font-family: Arial, sans-serif;
    margin: 0;
    padding: 0;
    box-sizing: border-box;
}

.motivacion {
    display: flex;
    justify-content: center;
    align-items: center;
    height: 50vh;
    background: none; /* Sin fondo */
    color: #333; /* Color de texto oscuro */
    text-align: center;
    padding: 0;
}

.motivacion p {
    font-size: 2em;
    font-style: italic;
    max-width: 800px;
    line-height: 1.5;
    color: #333; /* Color de texto oscuro */
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2); /* Sombra sutil */
    padding: 1em;
    border-radius: 10px;
    background: rgba(255, 255, 255, 0.9); /* Fondo blanco semitransparente */
}

.custom-caption{
  text-align: center;
  padding: 12px;
  color: white;
  background-color: rgba(0, 0, 0, .3)
}
.message {
  font-size: 32px; /* Tamaño más grande */
  margin-bottom: 20px;
  text-align: center; /* Alinear el texto al centro */
  font-style: italic; /* Cursiva */
}

.custom-padding {
  padding: 10% 20%; /* Ajusta el padding según tus necesidades */
}
footer {
    background-color: black;
    color: white;
    text-align: center;
    padding: 1em 0;
}

</style>
