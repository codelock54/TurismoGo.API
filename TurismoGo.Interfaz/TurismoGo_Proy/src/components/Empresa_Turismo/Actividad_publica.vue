<template>
  <div class="form-container">
    <h2 class="centered-title">Crear Actividad</h2>
    <form @submit.prevent="crearActividad">
      <div class="form-row">
        <div class="form-group">
          <label for="actividad">Actividad:</label>
          <input
            type="text"
            id="actividad"
            v-model="actividad.actividad"
            required
          />
          <span v-if="errors.actividad" class="error">{{
            errors.actividad
          }}</span>
        </div>

        <div class="form-group">
          <label for="nombreActividad">Nombre Actividad:</label>
          <input
            type="text"
            id="nombreActividad"
            v-model="actividad.nombreActividad"
            required
          />
          <span v-if="errors.nombreActividad" class="error">{{
            errors.nombreActividad
          }}</span>
        </div>
      </div>

      <div class="form-group">
        <label for="descripcion">Descripción:</label>
        <textarea
          id="descripcion"
          v-model="actividad.descripcion"
          required
        ></textarea>
        <span v-if="errors.descripcion" class="error">{{
          errors.descripcion
        }}</span>
      </div>

      <div class="form-row">
        <div class="form-group">
          <label for="destino">Destino:</label>
          <input
            type="text"
            id="destino"
            v-model="actividad.destino"
            required
          />
          <span v-if="errors.destino" class="error">{{ errors.destino }}</span>
        </div>

        <div class="form-group">
          <label for="precio">Precio:</label>
          <input
            type="number"
            id="precio"
            v-model.number="actividad.precio"
            required
          />
          <span v-if="errors.precio" class="error">{{ errors.precio }}</span>
        </div>
      </div>

      <div class="form-row">
        <div class="form-group">
          <label for="fechaInicio">Fecha Inicio:</label>
          <input
            type="date"
            id="fechaInicio"
            v-model="actividad.fechaInicio"
            required
          />
          <span v-if="errors.fechaInicio" class="error">{{
            errors.fechaInicio
          }}</span>
        </div>

        <div class="form-group">
          <label for="fechaFin">Fecha Fin:</label>
          <input
            type="date"
            id="fechaFin"
            v-model="actividad.fechaFin"
            required
          />
          <span v-if="errors.fechaFin" class="error">{{
            errors.fechaFin
          }}</span>
        </div>
      </div>

      <div v-if="dateError" class="form-group">
        <span class="error"
          >La fecha de inicio debe ser antes de la fecha de fin.</span
        >
      </div>

      <div class="form-group">
        <label for="idEmpresa">ID Empresa:</label>
        <input
          type="number"
          id="idEmpresa"
          v-model.number="actividad.idEmpresa"
          required
        />
        <span v-if="errors.idEmpresa" class="error">{{
          errors.idEmpresa
        }}</span>
      </div>

      <button type="submit">Crear Actividad</button>
    </form>
  </div>
</template>

<script>
import axios from "axios";

export default {
  data() {
    return {
      actividad: {
        actividad: "",
        nombreActividad: "",
        descripcion: "",
        destino: "",
        fechaInicio: "",
        fechaFin: "",
        precio: null,
        idEmpresa: 1,
      },
      errors: {},
      showSuccessModal: false,
      successTimeout: null,
      dateError: false,
    };
  },
  methods: {
    async crearActividad() {
      this.errors = {};
      this.dateError = false;

      if (this.actividad.fechaInicio >= this.actividad.fechaFin) {
        this.dateError = true;
        return;
      }

      try {
        const response = await axios.post(
          "http://localhost:5259/api/Actividad/Create",
          this.actividad
        );

        console.log("Actividad creada:", response.data);

        // Limpia el formulario
        this.actividad = {
          actividad: "",
          nombreActividad: "",
          descripcion: "",
          destino: "",
          fechaInicio: "",
          fechaFin: "",
          precio: null,
          idEmpresa: 1,
        };
        this.showSuccessModal = true;
        this.successTimeout = setTimeout(() => {
          this.showSuccessModal = false;
        }, 4000);
      } catch (error) {
        console.error("Error al crear actividad:", error);
        if (error.response && error.response.status === 400) {
          this.errors = error.response.data.errors;
        } else {
          this.errors.api = "Error inesperado al crear la actividad.";
        }
      }
    },

    hideSuccessModal() {
      this.showSuccessModal = false;
      clearTimeout(this.successTimeout);
    },
  },

  beforeUnmount() {
    clearTimeout(this.successTimeout);
  },
};
</script>

<style scoped>
.form-container {
  max-width: 600px;
  margin: auto;
  padding: 15px;
}

.centered-title {
  text-align: center;
  margin-bottom: 15px;
}

.form-group {
  margin-bottom: 15px;
}

.error {
  color: red;
}

.modal {
  display: block;
  position: fixed;
  z-index: 1;
  left: 0;
  top: 0;
  width: 90%;
  height: 90%;
  overflow: auto;
  background-color: rgba(0, 0, 0, 0.5);
}

.modal-content {
  background-color: #fefefe;
  margin: 15% auto;
  padding: 20px;
  border: 1px solid #888;
  width: 80%;
}

.close-btn {
  color: #aaa;
  float: right;
  font-size: 28px;
  font-weight: bold;
}

.close-btn:hover,
.close-btn:focus {
  color: black;
  text-decoration: none;
  cursor: pointer;
}

body {
  font-family: Arial, sans-serif;
  background-color: #f0f0f0;
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100vh;
  margin: 0;
}

.form-container {
  background-color: white;
  padding: 30px;
  border-radius: 8px;
  box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
  text-align: center; /* Centra el contenido */
}

.centered-title {
  text-align: center;
  color: #7f8ede;
  margin-bottom: 20px;
}

.form-row {
  display: flex;
  justify-content: space-between;
  margin-bottom: 15px;
}

.form-group {
  flex: 1;
  margin-right: 10px;
}

.form-group:last-child {
  margin-right: 0;
}
label {
  display: block;
  margin-bottom: 5px;
  text-align: left;
}

input,
textarea {
  width: 100%;
  padding: 8px;
  border: 1px solid #ccc;
  border-radius: 4px;
  box-sizing: border-box;
}

textarea {
  height: 80px;
}

.error {
  color: red;
  font-size: 12px;
  display: block;
  margin-top: 5px;
  text-align: left;
}
</style>
