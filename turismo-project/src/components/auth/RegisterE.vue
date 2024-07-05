<template>
  <q-page class="q-pa-md">
    <div class="form-container">
      <q-card class="form-card">
        <q-card-section>
          <h2 class="register-title">Registro de Empresa</h2>

          <q-form @submit="submitForm" ref="form">
            <q-input
              v-model="formData.nombre"
              label="Nombre"
              outlined
              dense
              class="input-spacing"
              :rules="[requiredRule('nombre'), maxLengthRule('nombre', 50)]"
            />
            <q-input
              v-model="formData.ruc"
              label="RUC"
              outlined
              dense
              class="input-spacing"
              :rules="[requiredRule('ruc'), maxLengthRule('ruc', 11)]"
            />
            <q-input
              v-model="formData.direccion"
              label="Dirección"
              outlined
              dense
              class="input-spacing"
              :rules="[requiredRule('dirección'), maxLengthRule('dirección', 100)]"
            />
            <q-input
              v-model="formData.telefono"
              label="Teléfono"
              outlined
              dense
              class="input-spacing"
              :rules="[requiredRule('teléfono'), maxLengthRule('teléfono', 15)]"
            />
            <q-input
              v-model="formData.email"
              label="Correo electrónico"
              outlined
              dense
              class="input-spacing"
              :rules="[requiredRule('email'), emailRule]"
            />
            <q-input
              v-model="formData.password"
              label="Contraseña"
              type="password"
              outlined
              dense
              class="input-spacing"
              :rules="[requiredRule('contraseña'), minLengthRule('contraseña', 6)]"
            />
            <q-input
              v-model="formData.repeatPassword"
              label="Repetir Contraseña"
              type="password"
              outlined
              dense
              class="input-spacing"
              :rules="[requiredRule('repetir contraseña'), minLengthRule('repetir contraseña', 6), passwordMatchRule]"
            />

            <div class="button-group">
              <q-btn type="submit" color="primary" label="Registrarse" class="submit-btn" @click="navigateTo('/')"/>
              <q-btn type="button" color="red" label="Cancelar" class="cancel-btn"  @click="confirm = true" />
            </div>
            <q-dialog v-model="confirm" persistent>
      <q-card>
        <q-card-section class="row items-center">
          <span class="q-ml-sm">¿Cancelar registro?</span>
        </q-card-section>

        <q-card-actions align="right">
          <q-btn flat label="Cancelar" color="primary" v-close-popup />
          <q-btn flat label="Cerrar sesión" color="primary" v-close-popup @click="navigateTo('/')"/>
        </q-card-actions>
      </q-card>
    </q-dialog>
          </q-form>
        </q-card-section>
      </q-card>
    </div>
  </q-page>
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
  data() {
    return {
      formData: {
        nombre: '',
        ruc: '',
        direccion: '',
        telefono: '',
        email: '',
        password: '',
      },
      emailRule: [
        val => !!val || 'El correo electrónico es requerido',
        val => /^[^\s@]+@[^\s@]+\.[^\s@]+$/.test(val) || 'Formato de correo electrónico inválido'
      ],
    };

  },
  methods: {
      navigateTo(route) {
      this.$router.push(route);
    },
    submitForm() {
      // Validar el formulario antes de enviar
      this.$refs.form.validate().then(success => {
        if (success) {
          // Lógica para enviar el formulario de registro si la validación pasa
          console.log('Formulario enviado', this.formData);
          // Aquí puedes agregar la lógica para enviar los datos a tu backend
          // Por ejemplo, enviar una solicitud HTTP POST al servidor
          // axios.post('/api/registro', this.formData)
          //   .then(response => {
          //     console.log('Registro exitoso', response.data);
          //     // Redirigir a la página de inicio de sesión u otra página
          //   })
          //   .catch(error => {
          //     console.error('Error en el registro', error);
          //     // Manejar errores de validación u otros errores
          //   });
        }
      });
    },
    requiredRule(field) {
      return [val => !!val || `El ${field} es requerido`];
    },
    maxLengthRule(field, maxLength) {
      return [val => (val && val.length <= maxLength) || `${field} debe tener menos de ${maxLength} caracteres`];
    },
    minLengthRule(field, minLength) {
      return [val => (val && val.length >= minLength) || `${field} debe tener al menos ${minLength} caracteres`];
    },
    passwordMatchRule() {
      return val => val === this.formData.password || 'Las contraseñas no coinciden';
    }
  }
};
</script>

<style scoped>
.q-card {
  max-width: 350px;
  margin: auto;
  background-color: #ffffff;
  border-radius: 8px;
  box-shadow: 0px 0px 20px rgba(0, 0, 0, 0.1);
}

.form-container {
  display: flex;
  justify-content: center;
  align-items: center;
  height: 100vh;
}

.form-card {
  width: 90%;
}

.q-card-section {
  padding: 10px; /* Reducir el padding para hacer el formulario más compacto */
}

.q-input {
  margin-bottom: 10px; /* Reducir el espacio entre casillas */
}

.button-group {
  display: flex;
  justify-content: space-between;
  margin-top: 20px;
}

.submit-btn {
  width: 48%;
}

.cancel-btn {
  width: 48%;
}

.register-title {
  text-align: center;
  margin-bottom: 20px;
  font-size: 30px;
  color: #333;
}

.input-spacing {
  margin-bottom: 10px;
}
</style>
