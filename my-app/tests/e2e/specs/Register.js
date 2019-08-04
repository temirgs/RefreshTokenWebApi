context("Cypress Demo", () => {
  it("Register Page", () => {
    cy.visit("http://localhost:8080/Register");
    //username
    cy.get("#rg_username").type("temir_gs19");
    //password
    cy.get("#rg_password").type("12345");
    //email
    cy.get("#rg_email").type("temir.gasimov@yahoo.com");
    //Click Register Button
    cy.get("#rg_buttonRegister").click();
  });
});
