context("Cypress Demo", () => {
  it("Login Page", () => {
    //Login page url
    cy.visit("http://localhost:8080/Login");
    //username
    cy.get("#username").type("temir_gs");
    //password
    cy.get("#password").type("12345");
    //Click Login Button
    cy.get("#login").click();
    ////////////////////////
    //LogOut
    cy.get("#Logout").click();
    cy.clearLocalStorage();
  });
});
