import { View, Text, TextInput } from 'react-native';
import { formStyles as s } from './formStyles';

export default function FormField({
  label,
  value,
  onChangeText,
  placeholder,
  keyboardType,
  autoCapitalize,
  maxLength,
  autoFocus,
  compact,
  secureTextEntry,
  multiline,
  editable = true,
  onSubmitEditing,
  returnKeyType,
}) {
  return (
    <View style={[s.field, compact && s.fieldCompact]}>
      {label ? <Text style={s.fieldLabel}>{label}</Text> : null}
      <TextInput
        style={s.input}
        value={value}
        onChangeText={onChangeText}
        placeholder={placeholder || label}
        placeholderTextColor="#94A3B8"
        keyboardType={keyboardType}
        autoCapitalize={autoCapitalize ?? 'sentences'}
        maxLength={maxLength}
        autoFocus={autoFocus}
        secureTextEntry={secureTextEntry}
        multiline={multiline}
        editable={editable}
        onSubmitEditing={onSubmitEditing}
        returnKeyType={returnKeyType}
      />
    </View>
  );
}
