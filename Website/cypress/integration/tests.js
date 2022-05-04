// /// <reference types="cypress" />
///https://on.cypress.io/introduction-to-cypress

describe('Final Year Project', () => {
    beforeEach(() => {
        cy.visit('http://bf118.webhosting.canterbury.ac.uk/')
    })

    it('can see four encounter links in Header', () => {

        cy.get('a').contains('Encounter1')
        cy.get('a').contains('Encounter2')
        cy.get('a').contains('Encounter3')
        cy.get('a').contains('Encounter4')
    })

    it('Clicks encounter 1 and 4 buttons', () => {
        cy.get('a').contains('Encounter1').click()

        cy.get('a').contains('Encounter4').click()
    })

    it('Open Discord invite', () => {
        cy.get('[alt="Discord"]').invoke('removeAttr', 'target').click()
    })

    it('Add username to role sign up', () => {
        cy.get('input[name=username]').type('testuser')
        cy.get('button').contains('Click here to sign up').click()
        cy.get('input[name=baseTank]').should('have.value', 'testuser')
    })

    it('Check role information', () => {
        cy.get('[alt=baseTank]').invoke('removeAttr', 'target').click()
        cy.get('p').contains('I am the base')
    })

    it('Can close modal', () => {
        cy.get('[alt=baseTank]').invoke('removeAttr', 'target').click()
        cy.get('[class="popup__close"]').contains('Press here to Close').click()
    })

    it('Checking search Feature', () => {
        cy.get('input[id=searchbox]').type('encounter2')
        cy.get('input[id=search]').contains('Go').click()
        cy.location('href').should('eq', 'http://bf118.webhosting.canterbury.ac.uk/encounter2.html');
    })

    it('Create Signup for Encounter 1', () => {
        cy.get('input[name=username]').type('testuser')
        cy.get('button').contains('Click here to sign up').click()
        cy.get('button[id=signUpDpsButton]').contains('Click here to sign up').click()
        cy.get('button[id=signUpAnyRoleButton]').contains('Click here to sign up').click()
        cy.get('input[name=baseTank]').should('have.value', 'testuser')
        cy.get('input[name=dps]').should('have.value', 'testuser')
        cy.get('input[name=anyrole]').should('have.value', 'testuser')
        cy.get('input[id=eventTime').type('12:31')
        cy.get('button').contains('Create Signup').click()
    })
    it('Lock Encounter1 signup sheet', () => {
        cy.get('input[name=username]').type('testuser')
        cy.get('button').contains('Click here to sign up').click()
        cy.get('button[id=signUpDpsButton]').contains('Click here to sign up').click()
        cy.get('button').contains('Lock Sign up').click()
    })

    it('Create Encounter1 signup sheet', () => {
        cy.get('input[name=username]').type('testuser')
        cy.get('button').contains('Click here to sign up').click()
        cy.get('button[id=signUpDpsButton]').contains('Click here to sign up').click()
        cy.get('button').contains('Clear Signup').click()
        cy.get('input[name=baseTank]').should('be.empty')
    })

})
