<template>
  <div class="q-pa-md">
    <q-card class="q-pa-sm">
      <q-card-section class="text-h6">
        Perfil
      </q-card-section>

      <q-card-section>
        <q-list bordered class="q-mb-sm q-pa-lg">
          <q-item class="q-pa-xs">
            <q-item-section>
              <q-item-label class="text-bold">Nombre:</q-item-label>
            </q-item-section>
            <q-item-section>
              <q-item-label>{{ user.nombre }}</q-item-label>
            </q-item-section>
          </q-item>

          <q-item class="q-pa-xs">
            <q-item-section>
              <q-item-label class="text-bold">Apellidos:</q-item-label>
            </q-item-section>
            <q-item-section>
              <q-item-label>{{ user.apellidos }}</q-item-label>
            </q-item-section>
          </q-item>

          <q-item class="q-pa-xs">
            <q-item-section>
              <q-item-label class="text-bold">DNI:</q-item-label>
            </q-item-section>
            <q-item-section>
              <q-item-label>{{ user.dni }}</q-item-label>
            </q-item-section>
          </q-item>

          <q-item class="q-pa-xs">
            <q-item-section>
              <q-item-label class="text-bold">Correo:</q-item-label>
            </q-item-section>
            <q-item-section>
              <q-item-label>{{ user.correo }}</q-item-label>
            </q-item-section>
          </q-item>

          <q-item class="q-pa-xs">
            <q-item-section>
              <q-item-label class="text-bold">Contraseña:</q-item-label>
            </q-item-section>
            <q-item-section>
              <q-item-label>{{ user.contrasena }}</q-item-label>
            </q-item-section>
          </q-item>
        </q-list>
      </q-card-section>

      <q-card-actions align="right">
        <q-btn icon="edit" @click="editProfile">Editar</q-btn>
      </q-card-actions>
    </q-card>
  </div>
</template>

<script>
import { ref } from 'vue'

export default {
  setup () {
    const user = ref({
      nombre: 'Juan',
      apellidos: 'Pérez',
      dni: '12345678',
      correo: 'juan.perez@example.com',
      contrasena: '********'
    })

    const editProfile = () => {
      // Implementar lógica de edición de perfil aquí
      console.log('Editar perfil')
    }

    return {
      user,
      editProfile
    }
  }
}
</script>

<style>
.text-bold {
  font-weight: bold;
}
.q-pa-xs {
  padding: 4px;
}
.q-mb-sm {
  margin-bottom: 8px;
}
</style>
