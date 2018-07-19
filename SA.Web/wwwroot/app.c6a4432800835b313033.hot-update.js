webpackHotUpdate("app",{

/***/ "./src/mock/mock.ts":
/*!**************************!*\
  !*** ./src/mock/mock.ts ***!
  \**************************/
/*! exports provided: default */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "default", function() { return Mock; });
/* harmony import */ var c_Work_solutions_git_github_simpleAuctionWebApi_SA_Web_node_modules_babel_runtime_helpers_builtin_es6_classCallCheck__WEBPACK_IMPORTED_MODULE_0__ = __webpack_require__(/*! ./node_modules/@babel/runtime/helpers/builtin/es6/classCallCheck */ "./node_modules/@babel/runtime/helpers/builtin/es6/classCallCheck.js");
/* harmony import */ var c_Work_solutions_git_github_simpleAuctionWebApi_SA_Web_node_modules_babel_runtime_helpers_builtin_es6_createClass__WEBPACK_IMPORTED_MODULE_1__ = __webpack_require__(/*! ./node_modules/@babel/runtime/helpers/builtin/es6/createClass */ "./node_modules/@babel/runtime/helpers/builtin/es6/createClass.js");
/* harmony import */ var axios__WEBPACK_IMPORTED_MODULE_2__ = __webpack_require__(/*! axios */ "./node_modules/axios/index.js");
/* harmony import */ var axios__WEBPACK_IMPORTED_MODULE_2___default = /*#__PURE__*/__webpack_require__.n(axios__WEBPACK_IMPORTED_MODULE_2__);
/* harmony import */ var _model_FuelEnum__WEBPACK_IMPORTED_MODULE_3__ = __webpack_require__(/*! @/model/FuelEnum */ "./src/model/FuelEnum.ts");





var Mock =
/*#__PURE__*/
function () {
  function Mock(adapter) {
    Object(c_Work_solutions_git_github_simpleAuctionWebApi_SA_Web_node_modules_babel_runtime_helpers_builtin_es6_classCallCheck__WEBPACK_IMPORTED_MODULE_0__["default"])(this, Mock);

    /**
     * Fake data of countries
     */
    this.countries = {
      cs: [{
        id: 1,
        name: 'Česká Republika'
      }, {
        id: 2,
        name: 'Německo'
      }, {
        id: 3,
        name: 'Slovenská Republika'
      }, {
        id: 4,
        name: 'Velká Británie'
      }, {
        id: 5,
        name: 'Rusko'
      }],
      en: [{
        id: 1,
        name: 'Czech Republic'
      }, {
        id: 2,
        name: 'Germany'
      }, {
        id: 3,
        name: 'Slovak Republic'
      }, {
        id: 4,
        name: 'Great Britain'
      }, {
        id: 5,
        name: 'Russia'
      }]
    };
    /**
     * Fake data collection
     */

    this.users = [{
      id: 1,
      userName: 'n00by',
      password: 'test',
      isActive: true,
      isAgreementToTerms: true,
      sendingNews: false,
      token: 'asdasdfqeoriqjwelkadf',
      language: 'en',
      customer: {
        id: 1,
        firstName: 'Jiri',
        lastName: 'Horalek',
        titleAfter: 'DiS.',
        email: 'horalek.jiri@gmail.com',
        isDealer: false,
        phoneNumber: '773587457',
        feeExpiration: new Date(2018, 7, 20, 0, 0, 0),
        birthNumber: '8110090560',
        address: {
          id: 1,
          street: 'Turpin court 458',
          city: 'Cambridge',
          postCode: 'CB4XY1',
          country: {
            id: 4,
            name: 'Great Britain'
          }
        }
      }
    }, {
      id: 2,
      userName: 'pavelNovak',
      password: 'test',
      isActive: true,
      isAgreementToTerms: true,
      sendingNews: true,
      token: '',
      language: 'cs',
      customer: {
        id: 2,
        firstName: 'Pavel',
        lastName: 'Novak',
        email: 'pavel.novak@seznam.cz',
        isDealer: false,
        phoneNumber: '772456928',
        feeExpiration: null,
        birthNumber: '6789234568',
        address: {
          id: 2,
          street: 'Prazska 125',
          city: 'Benesov u Prahy',
          postCode: '25601',
          country: {
            id: 1,
            name: 'Ceska Republika'
          }
        }
      }
    }];
    this.records = [{
      isActive: true,
      name: 'BMW 1',
      colors: ['#ff00ff', '#00ff00', '#00ffff'],
      mileage: '100000',
      engineCapacity: '1800 ccm',
      body: '5 dveří',
      power: '100 bhp',
      fuel: _model_FuelEnum__WEBPACK_IMPORTED_MODULE_3__["FuelEnum"].diesel,
      transmission: 'manual',
      axle: '',
      registrationCheck: 'tohle zatim nevi co ma byt',
      contactToAppointment: 'Katerina Horalkova, jelikat@seznam.cz',
      dealer: {
        id: 2,
        userName: 'pavelNovak',
        password: 'test',
        isActive: true,
        isAgreementToTerms: true,
        sendingNews: true,
        token: '',
        language: 'cs',
        customer: {
          id: 2,
          firstName: 'Pavel',
          lastName: 'Novak',
          email: 'pavel.novak@seznam.cz',
          isDealer: true,
          phoneNumber: '772456928',
          feeExpiration: null,
          birthNumber: '6789234568',
          address: {
            id: 2,
            street: 'Prazska 125',
            city: 'Benesov u Prahy',
            postCode: '25601',
            country: {
              id: 1,
              name: 'Ceska Republika'
            }
          }
        }
      },
      minimumBid: 5000,
      startingPrice: 50000,
      validFrom: new Date(2018, 5, 20),
      validTo: new Date(2018, 7, 20),
      defects: 'Karoserie je poskrabana, prmackliny na prednim blaniku. Opotrebovane brzdy, Popraskana sedadla.',
      moreDescription: 'Vice popisku muze byt zde',
      state: 'stav ???? asi v jakem je stavu',
      equipment: 'vybava. Elektrony dve sady, central, start na tlacitko atd.',
      vin: 'VUB56465465adf6a54645df',
      numberOfSeets: 5,
      euroNorm: '4',
      doors: 5,
      dateOfFirstRegistration: new Date(2004, 1, 1),
      stk: new Date(2018, 1, 23),
      dimensions: 'celkove rozmery',
      operationgWeight: 'provozni hmotnost',
      mostTechnicallyAcceptableWeight: 'nejvetsi technicka pripustna hmotnost',
      maximumWeight: 'maximalni povolena hmotnost',
      mostTechnicallyWeighOfRide: 'nejvetsi technicky pripustna hmotnost jizdni soupravy',
      maximumWeightOfRide: 'nejvetsi povolena hmotnost jizdni soupravy',
      files: [{
        id: 1,
        name: 'cockpit.jpg',
        path: '/auction'
      }, {
        id: 2,
        name: 'cockpit-1.jpg',
        path: '/auction'
      }, {
        id: 3,
        name: 'cockpit-2.jpg',
        path: '/auction'
      }, {
        id: 4,
        name: 'inside-front.jpg',
        path: '/auction'
      }, {
        id: 5,
        name: 'back-seats.jpg',
        path: '/auction'
      }, {
        id: 6,
        name: 'stearing-wheel.jpg',
        path: '/auction'
      }, {
        id: 7,
        name: 'mileage.jpg',
        path: '/auction'
      }, {
        id: 8,
        name: 'vin.jpg',
        path: '/auction'
      }, {
        id: 9,
        name: 'levers.jpg',
        path: '/auction'
      }, {
        id: 10,
        name: 'front-window-controls.jpg',
        path: '/auction'
      }, {
        id: 11,
        name: 'back-window-controls.jpg',
        path: '/auction'
      }, {
        id: 12,
        name: 'engine.jpg',
        path: '/auction'
      }],
      id: 1
    }, {
      isActive: true,
      name: 'Jawa 555',
      colors: ['#ab00ff', '#00eeee', '#bd84da'],
      mileage: '25000',
      engineCapacity: '50 ccm',
      body: '1 sedlo',
      power: '2,3 bhp',
      fuel: _model_FuelEnum__WEBPACK_IMPORTED_MODULE_3__["FuelEnum"].diesel,
      transmission: 'manual',
      axle: '',
      registrationCheck: 'tohle zatim nevi co ma byt',
      contactToAppointment: 'Jiri Horalek horalek.jiri@gmail.com',
      dealer: {
        id: 2,
        userName: 'pavelNovak',
        password: 'test',
        isActive: true,
        isAgreementToTerms: true,
        sendingNews: true,
        token: '',
        language: 'cs',
        customer: {
          id: 2,
          firstName: 'Pavel',
          lastName: 'Novak',
          email: 'pavel.novak@seznam.cz',
          isDealer: true,
          phoneNumber: '772456928',
          feeExpiration: null,
          birthNumber: '6789234568',
          address: {
            id: 2,
            street: 'Prazska 125',
            city: 'Benesov u Prahy',
            postCode: '25601',
            country: {
              id: 1,
              name: 'Ceska Republika'
            }
          }
        }
      },
      minimumBid: 1000,
      startingPrice: 5000,
      validFrom: new Date(2018, 5, 20),
      validTo: new Date(2018, 7, 20),
      defects: 'Prosezena sedacka, nestartuje, zaseknute brzdy.',
      moreDescription: 'rok vyroby 1959',
      state: 'Nalezovy stav. Nepojizdny',
      vin: '234144',
      numberOfSeets: 1,
      dateOfFirstRegistration: new Date(1959, 10, 22),
      files: [{
        id: 1,
        name: 'parez.jpg',
        path: '/auction'
      }],
      id: 2
    }, {
      isActive: true,
      name: 'Aprilia 125',
      colors: ['#ab00ff', '#00eeee', '#bd84da'],
      mileage: '25000',
      engineCapacity: '150 ccm',
      body: '1 sedlo',
      power: '15 bhp',
      fuel: _model_FuelEnum__WEBPACK_IMPORTED_MODULE_3__["FuelEnum"].diesel,
      transmission: 'manual',
      axle: '',
      registrationCheck: 'tohle zatim nevi co ma byt',
      contactToAppointment: 'Jiri Horalek horalek.jiri@gmail.com',
      dealer: {
        id: 2,
        userName: 'pavelNovak',
        password: 'test',
        isActive: true,
        isAgreementToTerms: true,
        sendingNews: true,
        token: '',
        language: 'cs',
        customer: {
          id: 2,
          firstName: 'Pavel',
          lastName: 'Novak',
          email: 'pavel.novak@seznam.cz',
          isDealer: true,
          phoneNumber: '772456928',
          feeExpiration: null,
          birthNumber: '6789234568',
          address: {
            id: 2,
            street: 'Prazska 125',
            city: 'Benesov u Prahy',
            postCode: '25601',
            country: {
              id: 1,
              name: 'Ceska Republika'
            }
          }
        }
      },
      minimumBid: 1000,
      startingPrice: 5000,
      validFrom: new Date(2018, 5, 20),
      validTo: new Date(2018, 7, 20),
      defects: 'Prosezena sedacka, nestartuje, zaseknute brzdy.',
      moreDescription: 'rok vyroby 1959',
      state: 'Nalezovy stav. Nepojizdny',
      vin: '234144',
      numberOfSeets: 1,
      dateOfFirstRegistration: new Date(1959, 10, 22),
      files: [{
        id: 1,
        name: 'engine.jpg',
        path: '/auction'
      }],
      id: 3
    }];
    this.mock = adapter;
  }
  /**
   * Get list of users without any filter
   * @returns Promise with list of Users
   */


  Object(c_Work_solutions_git_github_simpleAuctionWebApi_SA_Web_node_modules_babel_runtime_helpers_builtin_es6_createClass__WEBPACK_IMPORTED_MODULE_1__["default"])(Mock, [{
    key: "getUsers",
    value: function getUsers() {
      this.mock.onGet('/users').reply(200, {
        users: this.users
      });
      return axios__WEBPACK_IMPORTED_MODULE_2___default.a.get('/users');
    }
    /**
     * Get user by his ID
     * @param id - users d
     * @returns Promise with User object
     */

  }, {
    key: "getUser",
    value: function getUser(id) {
      this.mock.onGet('/users', {
        params: {
          id: id
        }
      }).reply(200, this.users.filter(function (x) {
        return x.id === id;
      })[0]);
      return axios__WEBPACK_IMPORTED_MODULE_2___default.a.get('/users', {
        params: {
          id: id
        }
      });
    }
    /**
     * Fake login user
     * @param userName - User's login name
     * @param password - User's password
     */

  }, {
    key: "login",
    value: function login(userName, password) {
      var filtered = this.users.filter(function (x) {
        return x.userName === userName && x.password === password;
      });
      this.mock.onGet('/users', {
        params: {
          userName: userName,
          password: password
        }
      }).reply(200, filtered.length > 0 ? filtered[0] : null);
      return axios__WEBPACK_IMPORTED_MODULE_2___default.a.get('/users', {
        params: {
          userName: userName,
          password: password
        }
      });
    }
    /**
     * Get list of countries
     * @param lang - lang
     */

  }, {
    key: "getCountries",
    value: function getCountries(lang) {
      this.mock.onGet('/countries').reply(200, this.countries[lang]);
      return axios__WEBPACK_IMPORTED_MODULE_2___default.a.get('/countries');
    }
    /**
     * Update user's token and return whole user back
     * @param id - User's id
     * @param token - new token string
     */

  }, {
    key: "updateUserToken",
    value: function updateUserToken(id, token) {
      var filtered = this.users.filter(function (x) {
        return x.id === id;
      }); // filtered[0].token = token;

      this.mock.onGet('/users', {
        params: {
          id: id
        }
      }).reply(200, filtered[0]);
      return axios__WEBPACK_IMPORTED_MODULE_2___default.a.get('/users', {
        params: {
          id: id
        }
      });
    }
    /**
     * Return user by his token string
     * @param token - Users token string
     */

  }, {
    key: "getUserByToken",
    value: function getUserByToken(token) {
      var filtered = this.users.filter(function (x) {
        return x.token === token;
      });
      this.mock.onGet('/users', {
        params: {
          token: token
        }
      }).reply(200, filtered[0]);
      return axios__WEBPACK_IMPORTED_MODULE_2___default.a.get('/users', {
        params: {
          token: token
        }
      });
    }
    /**
     * Get all records
     */

  }, {
    key: "getRecords",
    value: function getRecords() {
      this.mock.onGet('/records').reply(200, this.records);
      return axios__WEBPACK_IMPORTED_MODULE_2___default.a.get('/records');
    }
    /**
     * Get all active records
     */

  }, {
    key: "getAllActiveRecords",
    value: function getAllActiveRecords() {
      var date = new Date();
      var available = this.records.filter(function (x) {
        return x.validFrom <= date && x.validTo >= date && x.isActive;
      });
      this.mock.onGet('/records', {
        params: {
          date: date
        }
      }).reply(200, available);
      return axios__WEBPACK_IMPORTED_MODULE_2___default.a.get('/records', {
        params: {
          date: date
        }
      });
    }
    /**
     * Get record object by it's id
     * @param id - id of record
     */

  }, {
    key: "getRecordById",
    value: function getRecordById(id) {
      var date = new Date();
      var available = this.records.filter(function (x) {
        return x.validFrom <= date && x.validTo >= date && x.isActive;
      });
      this.mock.onGet('/records', {
        params: {
          id: id
        }
      }).reply(200, available.filter(function (x) {
        return x.id === id;
      })[0]);
      return axios__WEBPACK_IMPORTED_MODULE_2___default.a.get('/records', {
        params: {
          id: id
        }
      });
    }
  }]);

  return Mock;
}();



/***/ }),

/***/ "./src/model/FuelEnum.ts":
/*!*******************************!*\
  !*** ./src/model/FuelEnum.ts ***!
  \*******************************/
/*! exports provided: FuelEnum */
/***/ (function(module, __webpack_exports__, __webpack_require__) {

"use strict";
__webpack_require__.r(__webpack_exports__);
/* harmony export (binding) */ __webpack_require__.d(__webpack_exports__, "FuelEnum", function() { return FuelEnum; });
var FuelEnum;

(function (FuelEnum) {
  FuelEnum["petrol"] = "benz\xEDn";
  FuelEnum["diesel"] = "nafta";
  FuelEnum["other"] = "jin\xE9";
})(FuelEnum || (FuelEnum = {}));

/***/ })

})
//# sourceMappingURL=app.c6a4432800835b313033.hot-update.js.map