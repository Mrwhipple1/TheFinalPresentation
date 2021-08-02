<template>
  <div id="register" class="text-center">
    <div class="overlay"></div>
    <div class="popup">
      <div class="right-container">
        <h2></h2>
        <img
          src="https://i.imgur.com/6JguKva.png"
          alt="plannr logo"
          class="logo-image"
        />
        <p></p>
      </div>
      <form class="form-register" @submit.prevent="register">
        <h1 class="h3 mb-3 font-weight-normal" id="register-messege">
          Create Account
        </h1>
        <div class="alert alert-danger" role="alert" v-if="registrationErrors">
          {{ registrationErrorMsg }}
        </div>
        <label for="username" class="sr-only"></label>
        <input
          type="text"
          id="username"
          class="form-control"
          placeholder="Username"
          v-model="user.username"
          required
          autofocus
        />
        <label for="password" class="sr-only"></label>
        <input
          type="password"
          id="password"
          class="form-control"
          placeholder="Password"
          v-model="user.password"
          required
        />
        <input
          type="password"
          id="confirmPassword"
          class="form-control"
          placeholder="Confirm Password"
          v-model="user.confirmPassword"
          required
        />
        <router-link :to="{ name: 'login' }" class="login-link"
          >Have an account?</router-link
        >
        <button class="btn btn-lg btn-primary btn-block" type="submit">
          Create Account
        </button>
      </form>
    </div>
  </div>
</template>

<script>
import authService from "../services/AuthService";

export default {
  name: "register",
  data() {
    return {
      user: {
        username: "",
        password: "",
        confirmPassword: "",
        role: "user",
      },
      registrationErrors: false,
      registrationErrorMsg: "There were problems registering this user.",
    };
  },
  methods: {
    register() {
      if (this.user.password != this.user.confirmPassword) {
        this.registrationErrors = true;
        this.registrationErrorMsg = "Password & Confirm Password do not match.";
      } else {
        authService
          .register(this.user)
          .then((response) => {
            if (response.status == 201) {
              this.$router.push({
                path: "/login",
                query: { registration: "success" },
              });
            }
          })
          .catch((error) => {
            const response = error.response;
            this.registrationErrors = true;
            if (response.status === 400) {
              this.registrationErrorMsg = "Bad Request: Validation Errors";
            }
          });
      }
    },
    clearErrors() {
      this.registrationErrors = false;
      this.registrationErrorMsg = "There were problems registering this user.";
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

#register-messege {
  font-weight: bold;
  max-width: 325px;
  font-size: 23px;
  text-align: left;
  font-family: "Roboto", sans-serif;
  caret-color: transparent;
}

.logo-image {
  max-width: 400px;
}

.form-register {
  display: flex;
  margin: 100px 0px 0px 50px;
  max-width: 66%;
  flex-direction: column;

  z-index: 4;
}

form button {
  max-width: 150px;
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
  max-width: 150px;
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

.login-link {
  font-size: 13px;
  font-weight: bold;
  font-family: "Roboto", sans-serif;
  text-align: center;
  margin: 0px 0px 10px 0px;
  width: 120px;
  text-decoration: none;
  background-color: #dddddd;
  color: #333333;
  padding: 2px 6px 2px 6px;
  border-radius: 2em;
  caret-color: transparent;
}

.login-link:hover {
  font-size: 13px;
  font-weight: bold;
  font-family: "Roboto", sans-serif;
  margin: 0px 0px 10px 0px;
  width: 120px;
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
