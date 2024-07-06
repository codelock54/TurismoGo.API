<template>
  <div class="container">
    <h1 class="page-title text-center">Actividades Turismo</h1>
    <div class="row">
      <div
        v-for="actividad in actividades"
        :key="actividad.idActividad"
        class="col-md-4 mb-3"
      >
        <q-card class="actividad-card">
          <q-card-section class="bg-primary text-white">
            <div class="text-h6 text-center">
              {{ actividad.nombreActividad }}
            </div>
          </q-card-section>

          <q-img
            v-if="actividad.imagen"
            :src="actividad.imagen"
            class="card-image"
            :ratio="16 / 9"
          />

          <q-list dense>
            <q-item v-if="actividad.destino">
              <q-item-section><strong>Destino:</strong></q-item-section>
              <q-item-section>{{ actividad.destino }}</q-item-section>
            </q-item>
            <q-item>
              <q-item-section><strong>Fecha:</strong></q-item-section>
              <q-item-section>
                {{ formatDate(actividad.fechaInicio) }} -
                {{ formatDate(actividad.fechaFin) }}
              </q-item-section>
            </q-item>
            <q-item>
              <q-item-section><strong>Precio:</strong></q-item-section>
              <q-item-section>${{ actividad.precio }}</q-item-section>
            </q-item>
          </q-list>
        </q-card>
      </div>
    </div>
  </div>
</template>

<style scoped>
.container {
  padding: 20px;
}

.actividad-card {
  border: none;
  border-radius: 12px;
  overflow: hidden;
  box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
}

.page-title {
  font-size: 2rem;
  margin-bottom: 20px;
}
.q-card-section {
  padding: 16px;
}
.card-image {
  max-height: 200px;
  object-fit: cover;
}
.text-h6 {
  font-size: 1.25rem;
  font-weight: bold;
  margin-bottom: 8px;
}

.empresa-nombre {
  font-size: 0.875rem;
  color: #757575;
}

.q-list {
  padding: 0 16px 16px;
}

.q-item-section:first-child {
  font-weight: bold;
  color: #424242;
}

.q-item-section:last-child {
  color: #424242;
}
.bg-primary {
  background-color: #2196f3 !important; /* Use a vibrant blue */
}
</style>

<script>
import axios from "axios";

export default {
  data() {
    return {
      actividades: [],
    };
  },
  methods: {
    formatDate(dateString) {
      const date = new Date(dateString);
      return date.toLocaleDateString();
    },
    async getActividades() {
      try {
        const response = await axios.get(
          "http://localhost:5259/api/Actividad/GetAll"
        );
        this.actividades = response.data;
      } catch (error) {
        console.error("Error al obtener las actividades:", error);
      }
    },
  },
  mounted() {
    this.getActividades();
  },
};
</script>
