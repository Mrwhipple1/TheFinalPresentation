<template>
  <div id="login" class="text-center">
    <div class="overlay"></div>
    <div class="popup">
      <div class="right-container"></div>
      <form class="form-signin" @submit.prevent="login">
        <h1 class="h3 mb-3 font-weight-normal" id="sign-in-message">
          Sign in to access your account!
        </h1>
        <div class="alert alert-danger" role="alert" v-if="invalidCredentials">
          Invalid username and password!
        </div>
        <div
          class="alert alert-success"
          role="alert"
          v-if="this.$route.query.registration"
        >
          Thank you for registering, please sign in.
        </div>
        <input
          type="text"
          id="username"
          class="form-control"
          placeholder="Username"
          v-model="user.username"
          required
          autofocus
        />
        <input
          type="password"
          id="password"
          class="form-control"
          placeholder="Password"
          v-model="user.password"
          required
        />
        <router-link :to="{ name: 'register' }">Need an account?</router-link>
        <button type="submit">Sign in</button>
      </form>
    </div>
  </div>
</template>

<script>
import authService from "../services/AuthService";

export default {
  name: "login",
  components: {},
  data() {
    return {
      user: {
        username: "",
        password: "",
      },
      invalidCredentials: false,
    };
  },
  methods: {
    login() {
      authService
        .login(this.user)
        .then((response) => {
          if (response.status == 200) {
            this.$store.commit("SET_AUTH_TOKEN", response.data.token);
            this.$store.commit("SET_USER", response.data.user);
            this.$router.push("/");
          }
        })
        .catch((error) => {
          const response = error.response;

          if (response.status === 401) {
            this.invalidCredentials = true;
          }
        });
    },
  },
};
</script>

<style>
.overlay {
  position: fixed;
  top: 0px;
  left: 0px;
  width: 100%;
  /* opacity: 10%;
  backdrop-filter: blur(6px); */
  background: rgba(185, 185, 185, 0.5);
  height: 100vh;
  z-index: 1;
  display: block;
}

.popup {
  border-radius: 20px;
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  width: 600px;
  height: 500px;
  z-index: 2;
  background-color: white;
  box-shadow: 5px 5px 3px rgba(0, 0, 0, 0.2);
}

.right-container {
  border-radius: 0px 20px 20px 0px;
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(0, -50%);
  width: 600px;
  height: 500px;
  background: linear-gradient(to right, #ff4b2b, #ff416c);
  z-index: 3;
  width: 50%;
}

#sign-in-message {
  padding-left: 10px;
  font-weight: bold;
  max-width: 150px;
  font-size: 20px;
}

.form-signin {
  display: flex;
  margin: 25px;
  max-width: 50%;
  flex-direction: column;
  padding-left: 10px;
  z-index: 4;
}

form button {
  max-width: 25%;
}

.form-control {
  background-color: #eee;
  border: none;
  padding: 12px 15px;
  margin: 8px 0;
  width: 50%;
}
</style>