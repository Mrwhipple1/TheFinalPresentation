<template>
  <div id="login" class="text-center">
    <div class="overlay"></div>
    <div class="popup">
      <div class="right-container">
        <h2></h2>
        <img
          src="https://i.imgur.com/6JguKva.png"
          alt="plannr logo"
          class="logo-image"
        />
        <p>
          This will be a description of what Plannr is and allows you to do,
          basically an elevator pitch of the app. Lorem ipsum dolor sit amet,
          consectetur adipiscing elit, sed do eiusmod tempor incididunt ut
          labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
          exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.
          Duis aute irure dolor in reprehenderit in voluptate velit esse cillum
          dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non
          proident, sunt in culpa qui officia deserunt mollit anim id est
          laborum.
        </p>
      </div>
      <form class="form-signin" @submit.prevent="login">
        <h1 class="h3 mb-3 font-weight-normal" id="sign-in-message">
          Sign in to access your Plannr account!
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
        <router-link :to="{ name: 'register' }" class="register"
          >Need an account?</router-link
        >
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

<style scoped>
.overlay {
  position: fixed;
  top: 0px;
  left: 0px;
  width: 100%;
  /* opacity: 10%;
  backdrop-filter: blur(6px); */
  backdrop-filter: blur(3px);
  background: #9494946e;
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
  width: 800px;
  height: 600px;
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
  width: 800px;
  height: 600px;
  background: linear-gradient(to right, #ff4b2b, #ff416c);
  z-index: 2;
  width: 50%;
}

.right-container p {
  max-width: 400px;
  padding: 20px 20px 0px 20px;
  font-size: 20px;
  font-family: "Roboto", sans-serif;
  text-align: left;
}

#sign-in-message {
  font-weight: bold;
  max-width: 300px;
  font-size: 23px;
  text-align: left;
  font-family: "Roboto", sans-serif;
  caret-color: transparent;
}

.logo-image {
  max-width: 400px;
}

.form-signin {
  display: flex;
  margin: 100px 0px 0px 50px;
  max-width: 66%;
  flex-direction: column;

  z-index: 4;
}

form button {
  max-width: 110px;
  height: 30px;
  border: #ffffff;
  display: inline-block;
  padding: 0.3em 1.2em;
  margin: 0 0.3em 0.3em 0;
  border-radius: 2em;
  box-sizing: border-box;
  text-decoration: none;
  font-family: "Roboto", sans-serif;
  font-weight: 300;
  color: #ffffff;
  background-color: #585858;
  text-align: center;
  transition: all 0.2s;
  caret-color: transparent;
}

form button:hover {
  max-width: 110px;
  height: 30px;
  border: #ffffff;
  display: inline-block;
  padding: 0.3em 1.2em;
  margin: 0 0.3em 0.3em 0;
  border-radius: 2em;
  box-sizing: border-box;
  text-decoration: none;
  font-family: "Roboto", sans-serif;
  font-weight: 300;
  color: #ffffff;
  background-color: #141414;
  text-align: center;
  transition: all 0.2s;
  caret-color: transparent;
}

.form-control {
  background-color: #eee;
  border: none;
  padding: 12px 15px;
  margin: 8px 0;
  width: 50%;
}

.register {
  font: bold 11px Arial;
  margin: 0px 0px 10px 0px;
  width: 100px;
  text-decoration: none;
  background-color: #eeeeee;
  color: #333333;
  padding: 2px 6px 2px 6px;
  border-radius: 2em;
  caret-color: transparent;
}

.register:hover {
  font: bold 11px Arial;
  margin: 0px 0px 10px 0px;
  width: 100px;
  text-decoration: none;
  background-color: #bdbbbb;
  color: #333333;
  padding: 2px 6px 2px 6px;
  caret-color: transparent;
}

.alert {
  font-size: 13px;
  font-weight: bold;
  font-family: "Roboto", sans-serif;
  color: rgb(255, 0, 0);
  margin: 0px 0px 10px 0px;
}
</style>

