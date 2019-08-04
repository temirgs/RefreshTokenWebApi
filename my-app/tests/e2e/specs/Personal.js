context("Cypress Demo", () => {
  it("Add New Personal", () => {
    cy.visit("http://localhost:8080/Login");
    cy.get("#username").type("temir_gs");
    //imput'lara name vermediyme gore imput name coxdur
    cy.get("#password").type("12345");
    //Click Login Button
    cy.get("#login").click();
    //Name
    cy.get("#name").type("Temir");
    //Surname
    cy.get("#surname").type("Gasimov");
    //Phone Number
    cy.get("#phone").type("0515306533");
    //Brith Date
    cy.get("#brithdate").type("09.09.1999");
    //Click Add
    cy.get("#newpersonal").click();
  });
});
