/// <reference types="cypress" />
describe('Registration page', () => {

  const useremail = 'maci@laci2.com'
  const userpassword = 'macika2'
  const username = 'Macika2'

  beforeEach(() => {
    cy.visit('http://localhost:5173/signup')
  });

  it('Nagyszerű URL', () => {
    cy.url().should('eq', 'http://localhost:5173/signup')
  })

  it('Hibát jelenítsen meg, ha a felhasználónevet nem biztosítják', () => {
    cy.get('form').submit()
    cy.get('input[data-v-d48a5df4]').should('have.focus')
    // cy.contains('Username is required').should('be.visible')
  })

  it('El kell fogadnia egy érvényes felhasználónevet', () => {
    const validUsername = 'myusername'
    cy.get('input[data-v-d48a5df4]').type(validUsername)
    cy.get('form').submit()
    cy.get('input[data-v-d48a5df4]').should('not.have.focus')
    // cy.contains('Username is required').should('not.be.visible')
  })
});

