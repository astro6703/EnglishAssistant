import * as ko from 'knockout';

import './login.scss';

class LoginViewModel {
    private readonly password: KnockoutObservable<string>;
    private readonly confirmPassword: KnockoutObservable<string>;
    public readonly arePasswordsEqual: KnockoutComputed<boolean>;

    constructor() {
        this.password = ko.observable('');
        this.confirmPassword = ko.observable('');
        this.arePasswordsEqual = ko.pureComputed(() => this.password() === this.confirmPassword());
    }
}

ko.applyBindings(new LoginViewModel());